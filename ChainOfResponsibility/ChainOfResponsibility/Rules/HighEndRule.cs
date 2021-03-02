using System.Collections.Generic;
using System.Linq;
using ChainOfResponsibility.Model;

namespace ChainOfResponsibility.Rules
{
    public class HighEndRule : Rule
    {
        /// <summary>
        /// Just the highest card, so there is always a match.
        /// </summary>
        /// <param name="cards">The list of cards to check for a match</param>
        /// <returns>Boolean value indicating whether the given cards are a match</returns>
        public override Result IsMatch(List<Card> cards)
        {
            return new Result(cards, RuleName.HighCard);
        }
    }
}
