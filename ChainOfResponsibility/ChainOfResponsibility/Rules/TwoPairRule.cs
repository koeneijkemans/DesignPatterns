using System.Collections.Generic;
using System.Linq;
using ChainOfResponsibility.Model;

namespace ChainOfResponsibility.Rules
{
    public class TwoPairRule : Rule
    {
        /// <summary>
        /// Two different pairs of cards with the same value
        /// </summary>
        /// <param name="cards">The list of cards to check for a match</param>
        /// <returns>Boolean value indicating whether the given cards are a match</returns>
        public override Result IsMatch(List<Card> cards)
        {
            var groupedCards = cards.GroupBy(c => c.Rank);

            return groupedCards.Any(g => g.Count() >= 2) ? new Result(cards, RuleName.TwoPair) : Next.IsMatch(cards);
        }
    }
}
