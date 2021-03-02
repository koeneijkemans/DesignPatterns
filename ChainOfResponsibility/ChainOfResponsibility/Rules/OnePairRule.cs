using System.Collections.Generic;
using System.Linq;
using ChainOfResponsibility.Model;

namespace ChainOfResponsibility.Rules
{
    public class OnePairRule : Rule
    {
        /// <summary>
        /// One pair of cards with the same value
        /// </summary>
        /// <param name="cards"></param>
        /// <returns></returns>
        public override Result IsMatch(List<Card> cards)
        {
            var groupedCards = cards.GroupBy(c => c.Rank);

            return groupedCards.Count(g => g.Count() >= 2) == 1 ? new Result(cards, RuleName.OnePair) : Next.IsMatch(cards);
        }
    }
}
