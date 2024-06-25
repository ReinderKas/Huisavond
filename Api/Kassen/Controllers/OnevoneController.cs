using Kassen.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Kassen.Controllers
{
    [Route("onevone")]
    [ApiController]
    public class OnevoneController : ControllerBase
    {
        private readonly KassenContext _context;

        public OnevoneController(KassenContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Increase([FromQuery]string name,[FromQuery]bool winner)
        {
            var player = await _context.Players.FirstAsync(p => p.Name == name);

            if (player == null)
                return NotFound("Could not find the players.");

            player.ChangeDifficulty(winner ? -2 : 2);

            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}