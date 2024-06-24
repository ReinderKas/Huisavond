using Kassen.Database;
using Kassen.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;

namespace Kassen.Controllers
{
    [Route("drinkingBuddy")]
    [ApiController]
    public class DrinkingBuddyController : ControllerBase
    {
        private readonly KassenContext _context;

        public DrinkingBuddyController(KassenContext context)
        {
            _context = context;
        }

        [HttpGet]   
        public async Task<ActionResult<List<DrinkingBuddy>>> GetDrinkingBuddies()
        {
            foreach (var buddy in _context.DrinkingBuddy)
            {
                Console.WriteLine(buddy);
            }
            return Ok(_context.DrinkingBuddy);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromQuery]string from, [FromQuery]string to)
        {
            var fromPlayer = await _context.Players.FirstAsync(p => p.Name == from);
            var toPlayer = await _context.Players.FirstAsync(p => p.Name == to);

            if (fromPlayer == null || toPlayer == null)
                return NotFound("Could not find the players.");
            
            var drinkBuddy = new DrinkingBuddy(fromPlayer.Name, toPlayer.Name);

            Console.WriteLine("New Drinking Buddy");
            Console.WriteLine(drinkBuddy.ToString());
            
            await _context.DrinkingBuddy.AddAsync(drinkBuddy);
            await _context.SaveChangesAsync();
            
            return Ok();
        }
    }
}