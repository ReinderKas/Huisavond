using Kassen.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Kassen.Controllers
{
    [Route("fuckNeighbors")]
    [ApiController]
    public class FuckNeighborsController : ControllerBase
    {
        private readonly KassenContext _context;

        public FuckNeighborsController(KassenContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Increase([FromQuery]string name,[FromQuery]bool increase)
        {
            var player = await _context.Players.FirstAsync(p => p.Name == name);

            if (player == null)
                return NotFound("Could not find the players.");

            player.ChangeDifficulty(increase ? 1 : -2);

            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}