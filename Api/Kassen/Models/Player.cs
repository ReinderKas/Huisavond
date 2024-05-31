
namespace Kassen.Models;
public class Player : BaseEntity
{
    private string Name { get; set; }
    private int Difficulty { get; set; }
    private int TotalDrinks { get; set;}

    // Necessary for EF Core
    public Player() { }

    public Player(string name)
    {
        Name = name;
        Difficulty = 6;
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