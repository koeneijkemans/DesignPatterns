using System.Collections.Generic;
using System.Linq;
using ChainOfResponsibility.Model;

namespace ChainOfResponsibility.Rules
{
    public class ThreeOfAKindRule : Rule
    {
        /// <summary>
        /// Three cards with same value
        /// </summary>
        /// <param name="cards">The list of cards to check for a match</param>
        /// <returns>Boolean value indicating whether the given cards are a match</returns>
        public override Result IsMatch(List<Card> cards)
        {
            var groupedCards = cards.GroupBy(c => c.Rank);

            return groupedCards.Any(g => g.Count() >= 3) ? new Result(cards, RuleName.ThreeOfAKind) : Next.IsMatch(cards);
        }
    }
}
