using Kassen.Database;
using Kassen.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Kassen.Controllers
{
    [Route("api/[controller]")]
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

        [HttpPost]
        public async Task<ActionResult<CardGame>> CreateGame()
        {
            var game = new CardGame
            {
                Cards = GenerateDeck()
            };

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

        [HttpPost("{id}/draw")]
        public async Task<ActionResult<Card>> DrawCard(Guid id)
        {
            var game = await _context.Games.Include(g => g.Cards).FirstOrDefaultAsync(g => g.Id == id);

            if (game == null)
            {
                return NotFound();
            }

            var card = game.Cards.FirstOrDefault(c => !c.IsDrawn);

            if (card == null)
            {
                return NotFound("No more cards to draw.");
            }

            card.IsDrawn = true;
            await _context.SaveChangesAsync();

            return card;
        }

        private List<Card> GenerateDeck()
        {
            var suits = new[] { "Hearts", "Diamonds", "Clubs", "Spades" };
            var ranks = new[] { "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King", "Ace" };

            var deck = new List<Card>();

            foreach (var suit in suits)
            {
                foreach (var rank in ranks)
                {
                    deck.Add(new Card { Suit = suit, Rank = rank, IsDrawn = false });
                }
            }

            return deck.OrderBy(c => Guid.NewGuid()).ToList(); // Shuffle the deck
        }
    }
}