using Kassen.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Kassen.Controllers
{
    [Route("snakeEyes")]
    [ApiController]
    public class SnakeEyesController : ControllerBase
    {
        private readonly KassenContext _context;

        public SnakeEyesController(KassenContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromQuery]string name)
        {
            var player = await _context.Players.FirstAsync(p => p.Name == name);

            if (player == null)
                return NotFound("Could not find the players.");

            player.ChangeDifficulty(-2);
            await _context.SaveChangesAsync();
            
            return Ok();
        }
    }
}