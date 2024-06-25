using Kassen.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Kassen.Controllers
{
    [Route("loveNeighbors")]
    [ApiController]
    public class LoveNeighborsController : ControllerBase
    {
        private readonly KassenContext _context;

        public LoveNeighborsController(KassenContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Increase([FromQuery]string name,[FromQuery]bool increase)
        {
            var player = await _context.Players.FirstAsync(p => p.Name == name);

            if (player == null)
                return NotFound("Could not find the players.");

            player.ChangeDifficulty(increase ? 2 : -1);

            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}