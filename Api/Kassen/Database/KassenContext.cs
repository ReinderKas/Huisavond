using Kassen.Models;
using Microsoft.EntityFrameworkCore;
using Models;

namespace Kassen.Database;
public class KassenContext : DbContext
{
        public DbSet<DrinkingBuddy> DrinkingBuddy { get;}
        public DbSet<Player> Players { get; set; }
        

        
    public KassenContext(DbContextOptions<KassenContext> options)
        : base(options)
    { }
}
