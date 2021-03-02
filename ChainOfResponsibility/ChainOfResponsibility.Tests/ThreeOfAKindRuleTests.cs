using ChainOfResponsibility.Model;
using ChainOfResponsibility.Rules;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChainOfResponsibility.Tests
{
    [TestFixture]
    public class ThreeOfAKindRuleTests
    {
        [Test]
        public void IsMatch_ThreeCardsOfSameRank_IsAMatch()
        {
            List<Card> cards = new List<Card>
            {
                new Card(CardSuit.Diamonds, CardRank.Nine),
                new Card(CardSuit.Clubs, CardRank.Nine),
                new Card(CardSuit.Spades, CardRank.Nine)
            };

            ThreeOfAKindRule rule = new ThreeOfAKindRule();
            bool isMatch = rule.IsMatch(cards);

            Assert.AreEqual(true, isMatch);
        }

        [Test]
        public void IsMatch_ThreeCardsOfSameSuitNotSameRank_IsNoMatch()
        {
            List<Card> cards = new List<Card>
            {
                new Card(CardSuit.Diamonds, CardRank.Nine),
                new Card(CardSuit.Diamonds, CardRank.Eight),
                new Card(CardSuit.Diamonds, CardRank.Seven)
            };

            ThreeOfAKindRule rule = new ThreeOfAKindRule();
            bool isMatch = rule.IsMatch(cards);

            Assert.AreEqual(false, isMatch);
        }

        [Test]
        public void IsMatch_HandContainsTwoSetsOfThreeSameCards_IsMatch()
        {
            List<Card> cards = new List<Card>
            {
                new Card(CardSuit.Diamonds, CardRank.Nine),
                new Card(CardSuit.Clubs, CardRank.Nine),
                new Card(CardSuit.Spades, CardRank.Nine),
                new Card(CardSuit.Diamonds, CardRank.Four),
                new Card(CardSuit.Clubs, CardRank.Four),
                new Card(CardSuit.Spades, CardRank.Four),
            };

            ThreeOfAKindRule rule = new ThreeOfAKindRule();
            bool isMatch = rule.IsMatch(cards);

            Assert.AreEqual(true, isMatch);
        }
    }
}
