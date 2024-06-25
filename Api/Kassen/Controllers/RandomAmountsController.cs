using Kassen.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Kassen.Controllers
{
    [Route("randomAmount")]
    [ApiController]
    public class RandomAmountController : ControllerBase
    {
        private readonly KassenContext _context;

        public RandomAmountController(KassenContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromQuery]string name)
        {
            var player = await _context.Players.FirstAsync(p => p.Name == name);

            if (player == null)
                return NotFound("Could not find the players.");

            var drinks = player.Drink("RandomAmount");
            await _context.SaveChangesAsync();
            
            return Ok(drinks.ToString());
        }

        public static string[] Drinks = {
            "Wodka",
            "Rum",
            "Beerenburg",
        };
    }
}