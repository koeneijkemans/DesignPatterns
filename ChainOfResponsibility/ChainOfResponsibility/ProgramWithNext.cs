using ChainOfResponsibility.Model;
using ChainOfResponsibility.Rules;
using System;
using System.Collections.Generic;

namespace ChainOfResponsibility
{
    class ProgramWithNext
    {
        static void Main(string[] args)
        {
            List<Card> cards = new List<Card>
            {
                new Card(CardSuit.Clubs, CardRank.Ace),
                new Card(CardSuit.Diamonds, CardRank.Ace),
                new Card(CardSuit.Diamonds, CardRank.Queen),
                new Card(CardSuit.Hearts, CardRank.Queen),
                new Card(CardSuit.Clubs, CardRank.Queen),
            };

            var royalFlushRule = new RoyalFlushRule()
                .SetNext(new ThreeOfAKindRule())
                .SetNext(new TwoPairRule())
                .SetNext(new HighEndRule());

            var isMatch = royalFlushRule.IsMatch(cards);

            Console.WriteLine($"This is a match with: {isMatch.Rule}");
        }
    }
}
