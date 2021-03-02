using ChainOfResponsibility.Model;
using ChainOfResponsibility.Rules;
using NUnit.Framework;
using System.Collections.Generic;

namespace ChainOfResponsibility.Tests
{
    [TestFixture]
    public class RoyalFlushRuleTests
    {
        [Test]
        public void RoyalFlush_IsMatch_IsAMatchWithSevenCards()
        {
            List<Card> cards = new List<Card>
            {
                new Card(CardSuit.Clubs, CardRank.Ace),
                new Card(CardSuit.Clubs, CardRank.King),
                new Card(CardSuit.Clubs, CardRank.Queen),
                new Card(CardSuit.Clubs, CardRank.Jack),
                new Card(CardSuit.Clubs, CardRank.Ten),
                new Card(CardSuit.Clubs, CardRank.Nine),
                new Card(CardSuit.Clubs, CardRank.Eight)
            };

            RoyalFlushRule rule = new RoyalFlushRule();

            bool result = rule.IsMatch(cards);

            Assert.AreEqual(true, result);
        }

        [Test]
        public void RoyalFlush_CorrectRanksOtherSuit_NoMatch()
        {
            List<Card> cards = new List<Card>
            {
                new Card(CardSuit.Clubs, CardRank.Ace),
                new Card(CardSuit.Hearts, CardRank.King),
                new Card(CardSuit.Clubs, CardRank.Queen),
                new Card(CardSuit.Clubs, CardRank.Jack),
                new Card(CardSuit.Clubs, CardRank.Ten),
                new Card(CardSuit.Clubs, CardRank.Nine),
                new Card(CardSuit.Clubs, CardRank.Eight)
            };

            RoyalFlushRule rule = new RoyalFlushRule();

            bool result = rule.IsMatch(cards);

            Assert.AreEqual(false, result);
        }

        [Test]
        public void RoyalFlush_AllSameSuitNotCorrectRank_NoMatch()
        {
            List<Card> cards = new List<Card>
            {
                new Card(CardSuit.Clubs, CardRank.King),
                new Card(CardSuit.Clubs, CardRank.Queen),
                new Card(CardSuit.Clubs, CardRank.Jack),
                new Card(CardSuit.Clubs, CardRank.Ten),
                new Card(CardSuit.Clubs, CardRank.Nine),
                new Card(CardSuit.Clubs, CardRank.Eight),
                new Card(CardSuit.Clubs, CardRank.Seven),
            };

            RoyalFlushRule rule = new RoyalFlushRule();

            bool result = rule.IsMatch(cards);

            Assert.AreEqual(false, result);
        }

        [Test]
        public void RoyalFlush_OneCardMissingInHand_NoMatch()
        {
            List<Card> cards = new List<Card>
            {
                new Card(CardSuit.Clubs, CardRank.Ace),
                new Card(CardSuit.Clubs, CardRank.King),
                new Card(CardSuit.Clubs, CardRank.Queen),
                new Card(CardSuit.Clubs, CardRank.Jack)
            };

            RoyalFlushRule rule = new RoyalFlushRule();

            bool result = rule.IsMatch(cards);

            Assert.AreEqual(false, result);
        }

        [Test]
        public void RoyalFlush_DoubleRoyalFlushWithDifferentSuit_IsAMatch()
        {
            List<Card> cards = new List<Card>
            {
                new Card(CardSuit.Clubs, CardRank.Ace),
                new Card(CardSuit.Clubs, CardRank.King),
                new Card(CardSuit.Clubs, CardRank.Queen),
                new Card(CardSuit.Clubs, CardRank.Jack),
                new Card(CardSuit.Clubs, CardRank.Ten),
                new Card(CardSuit.Diamonds, CardRank.Ace),
                new Card(CardSuit.Diamonds, CardRank.King),
                new Card(CardSuit.Diamonds, CardRank.Queen),
                new Card(CardSuit.Diamonds, CardRank.Jack),
                new Card(CardSuit.Diamonds, CardRank.Ten),
            };

            RoyalFlushRule rule = new RoyalFlushRule();

            bool result = rule.IsMatch(cards);

            Assert.AreEqual(true, result);
        }

        [Test]
        public void RoyalFlush_DoubleRoyalFlushWithSameSuite_IsAMatch()
        {
            List<Card> cards = new List<Card>
            {
                new Card(CardSuit.Clubs, CardRank.Ace),
                new Card(CardSuit.Clubs, CardRank.King),
                new Card(CardSuit.Clubs, CardRank.Queen),
                new Card(CardSuit.Clubs, CardRank.Jack),
                new Card(CardSuit.Clubs, CardRank.Ten),
                new Card(CardSuit.Clubs, CardRank.Ace),
                new Card(CardSuit.Clubs, CardRank.King),
                new Card(CardSuit.Clubs, CardRank.Queen),
                new Card(CardSuit.Clubs, CardRank.Jack),
                new Card(CardSuit.Clubs, CardRank.Ten),
            };

            RoyalFlushRule rule = new RoyalFlushRule();

            bool result = rule.IsMatch(cards);

            Assert.AreEqual(true, result);
        }
    }
}
