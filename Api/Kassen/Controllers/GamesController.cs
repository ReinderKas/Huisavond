using Kassen.Database;
using Kassen.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Kassen.Controllers
{
    [Route("games")]
    [ApiController]
    public class GamesController : ControllerBase
    {
        private readonly KassenContext _context;

        public GamesController(KassenContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CardGame>>> GetGames()
        {
            return await _context.Games.Include(g => g.Cards).ToListAsync();
        }

        [HttpPost("create")]
        public async Task<ActionResult<CardGame>> CreateGame()
        {
            Console.WriteLine("Creating game");
            var game = new CardGame();

            _context.Games.Add(game);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetGame), new { id = game.Id }, game);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<CardGame>> GetGame(Guid id)
        {
            var game = await _context.Games.Include(g => g.Cards).FirstOrDefaultAsync(g => g.Id == id);

            if (game == null)
            {
                return NotFound();
            }

            return game;
        }

        [HttpPost("draw/{gameId}")]
        public async Task<ActionResult<Card>> DrawCard(Guid gameId)
        {
            var game = await _context.Games.FirstOrDefaultAsync(g => g.Id == gameId);

            if (game == null)
                return NotFound();

            var card = game.Draw();

            if (card == null)
                return NotFound("No more cards to draw.");

            card.IsDrawn = true;
            await _context.SaveChangesAsync();

            return card;
        }
        [HttpPost("add/{gameId}/{playerId}")]
        public ActionResult AddPlayerToGame(Guid playerId, Guid gameId)
        {
            var player = _context.Players.FirstOrDefault(p => p.Id == playerId);
            if (player == null)
                return NotFound("Player not found.");


            var game = _context.Games.FirstOrDefault(g => g.Id == gameId);
            if (game == null)
                return NotFound("Game not found.");

            game.Players.Add(player);
            _context.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete("remove/{playerId}/{gameId}")]
        public ActionResult RemovePlayerFromGame(Guid playerId, Guid gameId)
        {
            var player = _context.Players.FirstOrDefault(p => p.Id == playerId);
            if (player == null)
                return NotFound("Player not found.");


            var game = _context.Games.FirstOrDefault(g => g.Id == gameId);
            if (game == null)
                return NotFound("Game not found.");

            game.Players.Remove(player);
            _context.SaveChangesAsync();

            return Ok();
        }
    }
}