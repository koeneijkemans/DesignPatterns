using ChainOfResponsibility.Model;
using ChainOfResponsibility.Rules;
using NUnit.Framework;
using System.Collections.Generic;

namespace ChainOfResponsibility.Tests
{
    [TestFixture]
    public class TwoPairRuleTests
    {
        [Test]
        public void IsMatch_TwoCardsOfSameRank_IsMatch()
        {
            List<Card> cards = new List<Card>
            {
                new Card(CardSuit.Spades, CardRank.Ace),
                new Card(CardSuit.Clubs, CardRank.Ace)
            };

            TwoPairRule rule = new TwoPairRule();

            var isMatch = rule.IsMatch(cards);

            Assert.AreEqual(true, isMatch);
        }

        [Test]
        public void IsMatch_TwoSetsOfTwoCardsOfSameRank_IsMatch()
        {
            List<Card> cards = new List<Card>
            {
                new Card(CardSuit.Spades, CardRank.Ace),
                new Card(CardSuit.Clubs, CardRank.Ace),
                new Card(CardSuit.Spades, CardRank.Ten),
                new Card(CardSuit.Clubs, CardRank.Ten),
            };

            TwoPairRule rule = new TwoPairRule();

            var isMatch = rule.IsMatch(cards);

            Assert.AreEqual(true, isMatch);
        }

        [Test]
        public void IsMatch_ThreeCardsOfSameRank_IsMatch()
        {
            List<Card> cards = new List<Card>
            {
                new Card(CardSuit.Spades, CardRank.Ace),
                new Card(CardSuit.Clubs, CardRank.Ace),
                new Card(CardSuit.Diamonds, CardRank.Ace),
            };

            TwoPairRule rule = new TwoPairRule();

            var isMatch = rule.IsMatch(cards);

            Assert.AreEqual(true, isMatch);
        }

        [Test]
        public void IsMatch_TwoCardsOfSameSuit_IsNoMatch()
        {
            List<Card> cards = new List<Card>
            {
                new Card(CardSuit.Spades, CardRank.Ace),
                new Card(CardSuit.Spades, CardRank.Ten),
            };

            TwoPairRule rule = new TwoPairRule();

            var isMatch = rule.IsMatch(cards);

            Assert.AreEqual(false, isMatch);
        }

        [Test]
        public void IsMatch_OneCard_IsNoMatch()
        {
            List<Card> cards = new List<Card>
            {
                new Card(CardSuit.Spades, CardRank.Ace),
            };

            TwoPairRule rule = new TwoPairRule();

            var isMatch = rule.IsMatch(cards);

            Assert.AreEqual(false, isMatch);
        }
    }
}
