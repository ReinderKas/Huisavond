
using System.ComponentModel.DataAnnotations;
using SQLitePCL;

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

    public int Drink(string game)
    {
        var random = new Random();
        var mininum = Difficulty;
        var maximum = Difficulty + 6;
        var drinks = game switch
        {
            "Categories" => random.Next(mininum, maximum) / 2,
            "RandomAmount" => Math.Min(12, Math.Max(1, random.Next(mininum-3, maximum+3))),
            "DrinkingBuddy" => Convert.ToInt32(random.Next(mininum, maximum) * 2/3),
            _ => 12
        };

        TotalDrinks += drinks;
        Console.WriteLine($"{Name} is drinking {drinks} drinks.\n\n");
        return drinks;
    }

    public override string ToString()
        => $"Name: {Name}\n" +
            "  Difficulty: {Difficulty}\n" +
            "  Total Drinks: {TotalDrinks}\n";
}