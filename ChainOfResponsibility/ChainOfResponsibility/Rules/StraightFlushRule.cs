using System.Collections.Generic;
using System.Linq;
using ChainOfResponsibility.Model;

namespace ChainOfResponsibility.Rules
{
    public class StraightFlushRule : Rule
    {
        /// <summary>
        /// Straight Flush:
        /// Five cards in order, with the same suit.
        /// </summary>
        /// <param name="cards"></param>
        /// <returns></returns>
        public override Result IsMatch(List<Card> cards)
        {
            bool isSequence = true;
            Card highestCard = cards[0];
            for (int i = (cards.Count - 1); 
                i >= 0 && isSequence;
                i--)
            {
                isSequence = (highestCard.Rank - i) == cards[i].Rank;
            }

            bool sameSuit = cards.All((c) => c.Suit == CardSuit.Diamonds) ||
                cards.All((c) => c.Suit == CardSuit.Clubs) ||
                cards.All((c) => c.Suit == CardSuit.Hearts) ||
                cards.All((c) => c.Suit == CardSuit.Spades);

            return sameSuit && isSequence ? new Result(cards, RuleName.StraightFlush) : Next.IsMatch(cards);
        }
    }
}
