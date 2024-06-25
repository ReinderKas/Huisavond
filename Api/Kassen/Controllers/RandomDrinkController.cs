using Kassen.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Kassen.Controllers
{
    [Route("randomDrink")]
    [ApiController]
    public class RandomDrinkController : ControllerBase
    {
        private readonly KassenContext _context;

        public RandomDrinkController(KassenContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromQuery]string name)
        {
            var player = await _context.Players.FirstAsync(p => p.Name == name);

            if (player == null)
                return NotFound("Could not find the players.");

            player.TotalDrinks += 5;
            await _context.SaveChangesAsync();

            var drink = Drinks.ElementAt(new Random().Next(Drinks.Count()));
            Console.WriteLine(drink);
            
            return Ok(drink);
        }

        public static string[] Drinks = {
            "Wodka",
            "Rum",
            "Beerenburg",
        };
    }
}