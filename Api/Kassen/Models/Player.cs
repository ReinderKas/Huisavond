
using System.ComponentModel.DataAnnotations;

namespace Kassen.Models;
public class Player
{
    [Key]
    public string Name { get; set; }
    public int Difficulty { get; set; }
    public int TotalDrinks { get; set;}
    public bool isInRaffle { get; set; }

    // Necessary for EF Core
    public Player() { }

    public Player(string name, int difficulty)
    {
        Name = name;
        Difficulty = BetweenLimits(difficulty);
        TotalDrinks = 0;
        isInRaffle = false;
    }

    public int BetweenLimits(int difficulty){
        return Math.Min(Math.Max(difficulty, 1), 6);;
    }

    public void ChangeDifficulty(int difference)
        => Difficulty = BetweenLimits(Difficulty + difference);

    public override string ToString()
        => $"Name: {Name}\n" +
            "  Difficulty: {Difficulty}\n" +
            "  Total Drinks: {TotalDrinks}\n";
}