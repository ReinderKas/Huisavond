using Kassen.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.ObjectPool;

namespace Kassen.Controllers
{
    [Route("doubleDown")]
    [ApiController]
    public class DoubleDownController : ControllerBase
    {
        private readonly KassenContext _context;

        public DoubleDownController(KassenContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromQuery]string name, [FromQuery]bool success)
        {
            var player = await _context.Players.FirstAsync(p => p.Name == name);

            if (player == null)
                return NotFound("Could not find the players.");
            
            if (success){
                var diff = Convert.ToInt32(Math.Floor((double)player.Difficulty/2));
                player.Difficulty = Math.Max(1, diff);
                player.TotalDrinks += 5;
                await _context.SaveChangesAsync();
            } else {
                player.ChangeDifficulty(2);
            }

            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}