using MagnificentSuperHeroes.Shared;

namespace MagnificentSuperHeroes.Client.SuperHeroesService
{
    public interface ISuperHeroesService
    {
        
        List<SuperHero> Heroes { get; set; }

        List<Comic> Comics { get; set; }

        List<Team> Teams { get; set; }

        List<Difficulty> Difficulties { get; set; }

        Task GetComic();

        Task GetTeam();

        Task GetDifficulty();

        Task GetSuperHeroes();

        Task <SuperHero>GetSingleHero(int id);

        //Task CreateHero(SuperHero hero);

        //Task SetHeroes(HttpResponseMessage result);

        //Task DeleteHero(int id);
        //Task UpdateHero(SuperHero hero);



    }
}
