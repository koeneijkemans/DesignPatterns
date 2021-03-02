using System.Collections.Generic;
using System.Linq;
using ChainOfResponsibility.Model;

namespace ChainOfResponsibility.Rules
{
    public class FullHouseRule : Rule
    {
        /// <summary>
        /// One pair and a Three of a kind
        /// </summary>
        /// <param name="cards">The list of cards to check for a match as a full house</param>
        /// <returns>Boolean value indicating if the given cards are a full house</returns>
        public override bool IsMatch(List<Card> cards)
        {
            // Order the cards by rank, descending.
            List<Card> orderedCards = cards.OrderByDescending(card => card.Rank).ToList();

            // Check if the first two cards are the same rank and if the last 3 cards are the same rank.
            return (orderedCards[0].Rank == orderedCards[1].Rank)
                && (orderedCards[2].Rank == orderedCards[3].Rank && orderedCards[2].Rank == orderedCards[4].Rank);
        }
    }
}
