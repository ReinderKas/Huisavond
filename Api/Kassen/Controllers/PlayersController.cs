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
            Console.WriteLine("Creating Player\n");
            var newPlayer = new Player(name, difficulty);

            _context.Players.Add(newPlayer);
            _context.SaveChangesAsync();
            
            Console.WriteLine("Created Player", newPlayer.ToString());
            Console.WriteLine($"Created Player: {newPlayer.Name}  -  {newPlayer.Difficulty}");
            Console.WriteLine("\n\n\n");

            return CreatedAtAction(nameof(CreatePlayer), new { id = newPlayer.Name }, newPlayer);
        }
        
        [HttpDelete("/{name}")]
        public ActionResult<Player> DeletePlayer(string name)
        {
            var player = _context.Players.FirstOrDefault(p => p.Name == name);
            if (player == null)
                return NotFound("Player not found.");

            _context.Players.Remove(player);
            _context.SaveChangesAsync();

            return Ok();
        }
    }
}