using ChainOfResponsibility.Model;
using System.Collections.Generic;

namespace ChainOfResponsibility.Rules
{
    public abstract class Rule
    {
        protected Rule Next { get; private set; }

        public Rule SetNext(Rule nextRule)
        {
            var lastRule = this;

            while(lastRule.Next != null)
            {
                lastRule = lastRule.Next;
            }

            lastRule.Next = nextRule;
            return this;
        }

        /// <summary>
        /// Checks if the given list of cards is a match
        /// </summary>
        /// <param name="cards">The list of cards to check for a match</param>
        /// <returns>Boolean value indicating whether the given cards are a match</returns>
        public abstract Result IsMatch(List<Card> cards);
    }
}
