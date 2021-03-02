using ChainOfResponsibility.Rules;
using System.Collections.Generic;

namespace ChainOfResponsibility.Model
{
    public class Result
    {
        public List<Card> Cards { get; }

        public RuleName Rule { get; }

        public Result(List<Card> cards, RuleName rule)
        {
            Cards = cards;
            Rule = rule;
        }
    }
}
