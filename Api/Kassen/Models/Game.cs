using System.ComponentModel.DataAnnotations;
using Kassen.Models;


namespace Kassen.Games;
public abstract class Game{

    [Key]
    public Guid Id { get; set;}
    public string Name { get; }
    public IEnumerable<Player> Players { get; }


    public abstract void Drink();
}