using ChainOfResponsibility.Rules;
using ChainOfResponsibility.Model;
using NUnit.Framework;
using System.Collections.Generic;

namespace ChainOfResponsibility.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void StraightFlus_IsMatch()
        {
            var cards = new List<Card>
            {
                new Card(CardSuit.Clubs, CardRank.Ten),
                new Card(CardSuit.Clubs, CardRank.Nine),
                new Card(CardSuit.Clubs, CardRank.Eight),
                new Card(CardSuit.Clubs, CardRank.Seven),
                new Card(CardSuit.Clubs, CardRank.Six)
            };

            Rule rule = new StraightFlushRule()
                .SetNext(new EmptyTestRule());
            Result result = rule.IsMatch(cards);

            Assert.IsNotNull(result);
        }

        [Test]
        public void StraightFlus_NoSequence_IsNoMatch()
        {
            var cards = new List<Card>
            {
                new Card(CardSuit.Clubs, CardRank.Ten),
                new Card(CardSuit.Clubs, CardRank.Nine),
                new Card(CardSuit.Clubs, CardRank.Eight),
                new Card(CardSuit.Clubs, CardRank.Seven),
                new Card(CardSuit.Clubs, CardRank.Four)
            };

            Rule rule = new StraightFlushRule().SetNext(new EmptyTestRule());
            Result result = rule.IsMatch(cards);

            Assert.IsNull(result);
        }

        [Test]
        public void StraightFlus_DifferentSuit_IsNoMatch()
        {
            var cards = new List<Card>
            {
                new Card(CardSuit.Clubs, CardRank.Ten),
                new Card(CardSuit.Clubs, CardRank.Nine),
                new Card(CardSuit.Clubs, CardRank.Eight),
                new Card(CardSuit.Clubs, CardRank.Seven),
                new Card(CardSuit.Spades, CardRank.Six)
            };

            Rule rule = new StraightFlushRule().SetNext(new EmptyTestRule());
            Result result = rule.IsMatch(cards);

            Assert.IsNull(result);
        }
    }
}
