using Kassen.Database;
using Kassen.Games;
using Kassen.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.ObjectPool;

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

        [HttpGet("/{name}")]
        public async Task<ActionResult<Game>> GetGame([FromQuery] string name)
        {
            var result = await _context.Games.FirstAsync(g => g.Name == name);
            return Ok(result);
        }
    }
}