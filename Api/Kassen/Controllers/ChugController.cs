using Kassen.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.ObjectPool;

namespace Kassen.Controllers
{
    [Route("chug")]
    [ApiController]
    public class ChugController : ControllerBase
    {
        private readonly KassenContext _context;

        public ChugController(KassenContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromQuery]string name, [FromQuery]bool success)
        {
            var player = await _context.Players.FirstAsync(p => p.Name == name);

            if (player == null)
                return NotFound("Could not find the players.");
            
            player.TotalDrinks += 10;

            if (success)
                player.ChangeDifficulty(-1);
            else
                player.ChangeDifficulty(2);

            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}