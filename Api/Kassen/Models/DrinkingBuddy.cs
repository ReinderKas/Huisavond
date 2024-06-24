using System.ComponentModel.DataAnnotations;
using Kassen.Models;

namespace Models;
public class DrinkingBuddy{
    
    [Key]
    public Guid id { get; set; }
    public string From { get; set; }
    public string To { get; set; }

    public DrinkingBuddy(string from, string to)
    {
        From = from;
        To = to;
        id = Guid.NewGuid();
    }

    public DrinkingBuddy()
    {
        id = Guid.NewGuid(); // Optionally set the id here if not set externally
    }

    public override string ToString()
        => $"From: {From} \t To: {To}";
}