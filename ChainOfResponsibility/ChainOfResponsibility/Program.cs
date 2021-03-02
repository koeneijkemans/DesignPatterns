using ChainOfResponsibility.Model;
using ChainOfResponsibility.Rules;
using System;
using System.Collections.Generic;

namespace ChainOfResponsibility
{
    class Program
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

            List<Rule> rulesToMatch = new List<Rule>
            {
                new RoyalFlushRule(),
                new ThreeOfAKindRule(),
                new TwoPairRule(),
                new HighEndRule()
            };

            foreach (var rule in rulesToMatch)
            {
                var isMatch = rule.IsMatch(cards);
                if (isMatch != null)
                {
                    Console.WriteLine($"This is a {rule.GetType().Name}!");
                    return;
                }
                else
                {
                    Console.WriteLine($"No match for {rule.GetType().Name}");
                }
            }
        }
    }
}
