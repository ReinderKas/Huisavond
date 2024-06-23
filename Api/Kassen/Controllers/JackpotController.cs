using Kassen.Database;
using Kassen.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Kassen.Controllers
{
    [Route("jackpot")]
    [ApiController]
    public class JackpotController : ControllerBase
    {
        private readonly KassenContext _context;

        public JackpotController(KassenContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Player>>> GetPlayers()
        {
            var players = await _context.Players.Where(p => p.isInRaffle).ToListAsync();
            return Ok(players);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromQuery]string name)
        {
            var player = await _context.Players.FirstAsync(p => p.Name == name);
            if (player == null)
                return NotFound("Player not found: " + name);

            player.isInRaffle = true;
            await _context.SaveChangesAsync();
            
            return Ok();
        }
    }
}