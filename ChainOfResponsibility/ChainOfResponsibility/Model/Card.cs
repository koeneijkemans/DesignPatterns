namespace ChainOfResponsibility.Model
{
    public class Card
    {
        public CardSuit Suit { get; }

        public CardRank Rank { get; }

        public Card(CardSuit suit, CardRank rank)
        {
            Suit = suit;
            Rank = rank;
        }
    }
}
