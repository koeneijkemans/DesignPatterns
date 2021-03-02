using System.Collections.Generic;
using System.Linq;
using ChainOfResponsibility.Model;

namespace ChainOfResponsibility.Rules
{
    public class FlushRule : Rule
    {
        /// <summary>
        /// Five cards of the same suit
        /// </summary>
        /// <param name="cards"></param>
        /// <returns></returns>
        public override Result IsMatch(List<Card> cards)
        {
            bool sameSuit = cards.All((c) => c.Suit == CardSuit.Diamonds) ||
                cards.All((c) => c.Suit == CardSuit.Clubs) ||
                cards.All((c) => c.Suit == CardSuit.Hearts) ||
                cards.All((c) => c.Suit == CardSuit.Spades);

            return sameSuit ? new Result(cards, RuleName.Flush) : Next.IsMatch(cards);
        }
    }
}
