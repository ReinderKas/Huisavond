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

        [HttpPost]
        public ActionResult<Player> CreatePlayer(string name, int difficulty)
        {
            var newPlayer = new Player(name, difficulty);

            _context.Players.Add(newPlayer);
            _context.SaveChangesAsync();

            return CreatedAtAction(nameof(CreatePlayer), new { id = newPlayer.Name }, newPlayer);
        }
    }
}