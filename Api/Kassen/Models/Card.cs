namespace Kassen.Models
{
    public class Card : BaseEntity
    {
        public string Suit { get; set; }
        public string Rank { get; set; }
        public bool IsDrawn { get; set; }
    }
}