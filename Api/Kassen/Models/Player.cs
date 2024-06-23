
using System.ComponentModel.DataAnnotations;

namespace Kassen.Models;
public class Player
{
    [Key]
    public string Name { get; set; }
    public int Difficulty { get; set; }
    public int TotalDrinks { get; set;}

    // Necessary for EF Core
    public Player() { }

    public Player(string name, int difficulty)
    {
        Name = name;
        Difficulty = difficulty;
        TotalDrinks = 0;
    }

    public void SetDifficulty(int difficulty)
        => Difficulty = difficulty;

    public void ChangeDifficulty(int difference)
        => Difficulty += difference;

    public override string ToString()
        => $"Name: {Name}\n" +
            "  Difficulty: {Difficulty}\n" +
            "  Total Drinks: {TotalDrinks}\n";
}