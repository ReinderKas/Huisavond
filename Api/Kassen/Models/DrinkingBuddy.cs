using System.ComponentModel.DataAnnotations;
using Kassen.Models;

namespace Models;
public class DrinkingBuddy{
    
    [Key]
    public Guid id { get; set; }
    public Player Fucker { get; set; }
    public Player Fucked { get; set; }

    public DrinkingBuddy(Player from, Player to)
    {
        Fucker = from;
        Fucked = to;
        id = Guid.NewGuid();
    }
    public DrinkingBuddy()
    {
        id = Guid.NewGuid(); // Optionally set the id here if not set externally
    }
}