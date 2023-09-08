using MagnificentSuperHeroes.Shared;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;
using static System.Net.WebRequestMethods;

namespace MagnificentSuperHeroes.Client.SuperHeroesService
{
    public class SuperHeroesService : ISuperHeroesService
    {
        private readonly HttpClient _httpClient;
        private readonly NavigationManager _navigationManager;

        public SuperHeroesService(HttpClient httpClient, NavigationManager navigationManager)
        {
            _httpClient = httpClient;
            _navigationManager = navigationManager;
        }

        public List<SuperHero> Heroes {get; set;} = new List<SuperHero>();
        public List<Comic> Comics { get; set; } = new List<Comic>();    
        public List<Team> Teams { get; set; } = new List<Team>();
        public List<Difficulty> Difficulties { get; set; } = new List<Difficulty>();

       

        bool isNew = true;

        public async Task GetComic()
        {
            var result = await _httpClient.GetFromJsonAsync<List<Comic>>("api/superheroes/comics");
            if (result != null)
            {
                Comics = result;
            }
        }

        public async Task GetTeam()
        {
            var result = await _httpClient.GetFromJsonAsync<List<Team>>("api/superheroes/teams");
            if (result != null)
            {
                Teams = result;
            }
        }

        public async Task GetDifficulty()
        {
            var result = await _httpClient.GetFromJsonAsync<List<Difficulty>>("api/superheroes/difficulties");
            if (result != null)
            {
                Difficulties = result;
            }
        }

        public async Task<SuperHero>GetSingleHero(int id)
        {
            var result = await _httpClient.GetFromJsonAsync<SuperHero>($"api/superhero/{id}");
            if(result != null)
            {
                return  result;
            }
            throw new Exception("Hero not found!");
        }

        public async Task GetSuperHeroes()
        {
            var result = await _httpClient.GetFromJsonAsync<List<SuperHero>>("api/superhero");
            if (result != null)
            {
                Heroes = result;
            }
        }

        //    public async Task CreateHero(SuperHero hero)
        //    {
        //        var result = await _httpClient.PostAsJsonAsync("api/superhero", hero);
        //        await SetHeroes(result);

        //    }

        //    public async Task SetHeroes(HttpResponseMessage result)
        //    {

        //        var response = await result.Content.ReadFromJsonAsync<List<SuperHero>>();
        //        Heroes = response;
        //        _navigationManager.NavigateTo("superheroes");

        //    }

        //    public async Task DeleteHero(int id)
        //    {
        //        var result = await _httpClient.DeleteAsync($"api/superhero/{id}");
        //        await SetHeroes(result);
        //    }

        //    public async Task UpdateHero(SuperHero hero)
        //    {
        //        var result = await _httpClient.PutAsJsonAsync($"api/superhero/{hero.Id}", hero);
        //        await SetHeroes(result);
        //    }
    }
}
