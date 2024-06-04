namespace Kassen.Models
{
    public class CardGame : BaseEntity
    {
        public List<Card> Cards { get; set; }
        public List<Player> Players { get; set; }

        public CardGame(bool shuffle = true)
        {
            if (Cards == null){
                Cards = GenerateDeck();
            }
            if (shuffle){
                Cards = Cards.OrderBy(c => Guid.NewGuid()).ToList(); // Shuffle the deck
            }   
        }

        private List<Card> GenerateDeck()
        {
            var suits = new[] { "Hearts", "Diamonds", "Clubs", "Spades" };
            var ranks = new[] { "Ace" , "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King" };

            var deck = new List<Card>();
            int order = 0;
            foreach (var suit in suits)
            {
                foreach (var rank in ranks)
                {
                    deck.Add(new Card { Suit = suit, Rank = rank, IsDrawn = false });
                    order++;
                }
            }

            // Set order.
            for(int i = 0; i < Cards.Count(); i++){
                Cards[i].Order = i;
            }

            return deck;
        } 

        public Card Draw(){            
            var card = Cards.FirstOrDefault(c => !c.IsDrawn);

            if (card == null)
                return null;
                
            card.IsDrawn = true;
            return card;    
        }
    }
}