using Kassen.Models;


// TODO: Rename Goblet Of Fire?
namespace Kassen.Games;
public class Jackpot
{
    private List<Player> _players;
    private static Random _random;
    
    public Jackpot()
    {
        _players = new List<Player>();
        _random = new Random();
    }

    public void AddPlayer(Player player)
        => _players.Add(player);
        
    public Player Draw(Player player)
        => _players.ElementAt(_random.Next(_players.Count));

    public void PrintPlayers()
    {
        foreach (var player in _players)
            Console.WriteLine(player.ToString());
    }
}