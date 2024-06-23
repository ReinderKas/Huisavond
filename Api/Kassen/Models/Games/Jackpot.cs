using Kassen.Models;


// TODO: Rename Goblet Of Fire?
namespace Kassen.Games;
public class Jackpot : Game
{
    private static Random _random;
    private List<Player> _players;
    
    
    public string Name => "Jackpot";
    public IEnumerable<Player> Players => _players;


    public Jackpot()
    {
        _random = new Random();
    }



    public void AddPlayer(Player player)
        => _players.Add(player);
        

    public void PrintPlayers()
    {
        foreach (var player in _players)
            Console.WriteLine(player.ToString());
    }

    public override void Drink()
    {
        throw new NotImplementedException();
    }

}