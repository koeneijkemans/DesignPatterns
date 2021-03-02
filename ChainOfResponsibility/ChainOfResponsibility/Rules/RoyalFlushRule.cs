using ChainOfResponsibility.Model;
using System.Collections.Generic;
using System.Linq;

namespace ChainOfResponsibility.Rules
{
    public class RoyalFlushRule : Rule
    {
        /// <summary>
        /// 10, Jack, Queen, King, Ace of the same suite.
        /// Best possible hand.
        /// </summary>
        /// <param name="cards">The list of cards to check for a match</param>
        /// <returns>Boolean value indicating whether the given cards are a match</returns>
        public override Result IsMatch(List<Card> cards)
        {
            IEnumerable<IGrouping<CardSuit, Card>> cardsBySuit = cards.GroupBy(card => card.Suit);

            bool isRoyalFlush = cardsBySuit.Any(grouped => grouped.Any(card => card.Rank == CardRank.Ace) 
                                            && grouped.Any(card => card.Rank == CardRank.King) 
                                            && grouped.Any(card => card.Rank == CardRank.Queen) 
                                            && grouped.Any(card => card.Rank == CardRank.Jack) 
                                            && grouped.Any(card => card.Rank == CardRank.Ten));

            return isRoyalFlush ? new Result(cards, RuleName.RoyalFlush) : Next.IsMatch(cards);
        }
    }
}
