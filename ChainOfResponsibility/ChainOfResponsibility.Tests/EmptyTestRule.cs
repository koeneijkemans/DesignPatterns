using ChainOfResponsibility.Model;
using ChainOfResponsibility.Rules;
using System.Collections.Generic;

namespace ChainOfResponsibility.Tests
{
    internal class EmptyTestRule : Rule
    {
        public override Result IsMatch(List<Card> cards)
        {
            return null;
        }
    }
}
