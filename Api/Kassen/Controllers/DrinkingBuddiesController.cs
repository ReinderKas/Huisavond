using Kassen.Database;
using Kassen.Models;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;

namespace Kassen.Controllers
{
    [Route("drinkingBuddy")]
    [ApiController]
    public class DrinkingBuddyController : ControllerBase
    {
        private readonly KassenContext _context;

        public DrinkingBuddyController(KassenContext context)
        {
            _context = context;
        }

        [HttpGet]   
        public async Task<ActionResult<List<DrinkingBuddy>>> GetDrinkingBuddies()
        {
            foreach (var buddy in _context.DrinkingBuddy)
            {
                Console.WriteLine(buddy);
            }
            return Ok(_context.DrinkingBuddy);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromQuery]string name, [FromQuery]string skip = "")
        {
            var player = await _context.Players.FirstAsync(p => p.Name == name);

            var drinkingBuddies = await _context.DrinkingBuddy.ToListAsync();
 
            var newBuddies = new List<string>();
            var hasBeenDrawn = new HashSet<string>();
            
            hasBeenDrawn.Add(player.Name);
            do
            {
                var buddies = drinkingBuddies.Where(db => hasBeenDrawn.Contains(db.From) ||
                                                           hasBeenDrawn.Contains(db.To));
                var fromBuddies = buddies.Select(b => b.From);
                var toBuddies = buddies.Select(b => b.To);

                var allBuddies = fromBuddies.Concat(toBuddies).Distinct();

                foreach(var bud in allBuddies){
                    if (!hasBeenDrawn.Contains(bud))
                    {
                        hasBeenDrawn.Add(bud);
                    }
                }

                newBuddies = allBuddies.Except(hasBeenDrawn).ToList();
            }while(newBuddies.Count > 0);


            var players = await _context.Players.Where(p => hasBeenDrawn.Contains(p.Name)).ToListAsync();
        
            var skipped = players.FirstOrDefault(p => p.Name == skip);

            if (skip != "" && skipped != null)
            {
                players.Remove(skipped);
                skipped.TotalDrinks += 5;
            }

            var resultString = "";
            foreach (var p in players)
            {
                var drinks = p.Drink("DrinkingBuddy");
                resultString += $"{drinks} \t {p.Name} \n";
            }

            await _context.SaveChangesAsync();
            return Ok(resultString);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromQuery]string from, [FromQuery]string to)
        {
            Player fromPlayer = null;
            Player toPlayer = null;
            try{
                fromPlayer = await _context.Players.FirstAsync(p => p.Name == from);
                toPlayer = await _context.Players.FirstAsync(p => p.Name == to);
            }
            catch{
                return NotFound("Could not find the players.");
            }
            
            var drinkBuddy = new DrinkingBuddy(fromPlayer.Name, toPlayer.Name);

            Console.WriteLine("New Drinking Buddy");
            Console.WriteLine(drinkBuddy.ToString());
            
            await _context.DrinkingBuddy.AddAsync(drinkBuddy);
            await _context.SaveChangesAsync();
            
            return Ok();
        }            

        public static string[] Drinks = {
            "Wodka",
            "Rum",
            "Beerenburg",
        };
    }
}