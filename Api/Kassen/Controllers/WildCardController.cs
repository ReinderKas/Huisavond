using Kassen.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.ObjectPool;

namespace Kassen.Controllers
{
    [Route("wildcard")]
    [ApiController]
    public class WildcardController : ControllerBase
    {
        private readonly KassenContext _context;

        public WildcardController(KassenContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromQuery]string name, [FromQuery]bool increment)
        {
            var player = await _context.Players.FirstAsync(p => p.Name == name);

            if (player == null)
                return NotFound("Could not find the players.");
            
            player.ChangeDifficulty(increment ? 1 : -1);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}