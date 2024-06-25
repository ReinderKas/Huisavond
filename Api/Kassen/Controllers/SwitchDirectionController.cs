using Kassen.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Kassen.Controllers
{
    [Route("switchDirection")]
    [ApiController]
    public class SwitchDirectionController : ControllerBase
    {
        private readonly KassenContext _context;

             public SwitchDirectionController(KassenContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromQuery]string name, [FromQuery]bool clockwise)
        {
            var player = await _context.Players.FirstAsync(p => p.Name == name);

            if (player == null)
                return NotFound("Could not find the players.");
            
            player.ChangeDifficulty(clockwise ? -2 : 2);
            
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}