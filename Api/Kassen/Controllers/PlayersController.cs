using Kassen.Database;
using Kassen.Models;
using Microsoft.AspNetCore.Mvc;

namespace Api.Kassen.Controllers
{
    [ApiController]
    [Route("players")]
    public class PlayersController : ControllerBase
    {
        private readonly KassenContext _context;

        public PlayersController(KassenContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Player>> GetPlayers()
        {
            return Ok(_context.Players);
        }

        [HttpPost("/create/{name}")]
        public ActionResult<Player> CreatePlayer(string name)
        {
            var newPlayer = new Player(name);

            _context.Players.Add(newPlayer);
            _context.SaveChangesAsync();

            return CreatedAtAction(nameof(CreatePlayer), new { id = newPlayer.Id }, newPlayer);
        }
        
        [HttpDelete("/{playerId}")]
        public ActionResult<Player> DeletePlayer(Guid id)
        {
            var player = _context.Players.FirstOrDefault(p => p.Id == id);
            if (player == null)
                return NotFound("Player not found.");

            _context.Players.Remove(player);
            _context.SaveChangesAsync();

            return Ok();
        }
    }
}