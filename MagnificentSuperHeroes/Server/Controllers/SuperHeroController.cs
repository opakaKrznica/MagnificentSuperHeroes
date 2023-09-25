using Microsoft.AspNetCore.Mvc;


namespace MagnificentSuperHeroes.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        private readonly DataContext _context;

        public SuperHeroController(DataContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<ActionResult<List<SuperHero>>> GetSuperHeroes()
        {
            var heroes = await _context.SuperHeroes
                .Include(h => h.Comic)
                .Include(h => h.Team)
                .Include(h => h.Difficulty)
                .ToListAsync();
            return Ok(heroes);
        }

        [HttpGet("{id}")]

        public async Task<ActionResult<SuperHero>> GetSingleSuperHero(int id)
        {
            var hero = await _context.SuperHeroes
                .Include(h => h.Comic)
                .Include(h => h.Team)
                .Include(h => h.Difficulty)
                .FirstOrDefaultAsync(h => h.Id == id);
            if (hero == null)
            {
                return NotFound("Sorry, no heroes here. :/");
            }
            return Ok(hero);
        }

        [HttpGet("comics")]
        public async Task<ActionResult<List<Comic>>> GetComics()
        {
            var comics = await _context.Comics.ToListAsync();
            return Ok(comics);
        }

        [HttpGet("teams")]
        public async Task<ActionResult<List<Team>>> GetTeams()
        {
            var teams = await _context.Teams.ToListAsync();
            return Ok(teams);
        }

        [HttpGet("difficulties")]
        public async Task<ActionResult<List<Difficulty>>> GetDifficulty()
        {
            var difficulties = await _context.Difficulties.ToListAsync();
            return Ok(difficulties);
        }

        [HttpPost]

        public async Task<ActionResult<SuperHero>>CreateSuperHero(SuperHero hero)
        {
            hero.Comic = null;
            hero.Team = null;
            hero.Difficulty = null;
            _context.SuperHeroes.Add(hero);
            await _context.SaveChangesAsync();

            return Ok(await GetDbHeroes());
        }

        [HttpPut("{Id}")]

        public async Task<ActionResult<SuperHero>> UpdateSuperHero(SuperHero hero, int id)
        {
            var dbHero = await _context.SuperHeroes
                 .Include(h => h.Comic)
                .Include(h => h.Team)
                .Include(h => h.Difficulty)                
                .FirstOrDefaultAsync(h => h.Id == id);

            if (dbHero == null)
                return NotFound("Sorry, no Hero for you. :/");

            dbHero.Name = hero.Name;
            dbHero.HeroName = hero.HeroName;
            dbHero.Bio = hero.Bio;
            dbHero.BirthDate = hero.BirthDate;
            dbHero.TeamId = hero.TeamId;
            dbHero.ComicId = hero.ComicId;
            dbHero.DifficultyId = hero.DifficultyId;
            dbHero.IsReadyToFight = hero.IsReadyToFight;
            dbHero.Image = hero.Image;  

            await _context.SaveChangesAsync();

            return Ok(await GetDbHeroes());
        }

        [HttpDelete("{Id}")]

        public async Task<ActionResult<SuperHero>> DeleteSuperHero(int id)
        {
            var dbHero = await _context.SuperHeroes
                  .Include(h => h.Comic)
                  .Include(h => h.Team)
                  .Include(h => h.Difficulty)                  
                  .FirstOrDefaultAsync(sh => sh.Id == id);

            if (dbHero == null)
                return NotFound("Sorry, no Hero for you. :/");

            _context.SuperHeroes.Remove(dbHero);
            await _context.SaveChangesAsync();

            return Ok(await GetDbHeroes());
        }

        private async Task<List<SuperHero>> GetDbHeroes()
        {
            return await _context.SuperHeroes
                .Include(sh => sh.Comic)
                .Include(h => h.Team)
                .Include(hx=> hx.Difficulty)                
                .ToListAsync();
        }
    }
}
