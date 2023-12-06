using System.Collections.Generic;
using System.Linq;

namespace Day4
{
    public class CardProcessor
    {
        public Dictionary<int,Card> Cards { get; set; }
        private Queue<int> CardsToProcess { get; set; } = new();
        public int CountOfCardsProcessed { get; private set; }

        public int Process(List<Card> cards)
        {
            CardsToProcess.Clear();
            Cards = cards.ToDictionary(c => c.Id, c=>c);
            Cards.Keys.ToList().ForEach(CardsToProcess.Enqueue);

            while (CardsToProcess.Any())
            {
                var cardId = CardsToProcess.Dequeue();
                var card = Cards[cardId];
                ProcessCard(card);
                CountOfCardsProcessed++;
            }

            return CountOfCardsProcessed;
        }

        public void ProcessCard(Card card)
        {
            var cardCopies = card.MatchingNumbers.Select((c, index) => card.Id + index+1).ToList();
            cardCopies.ForEach(CardsToProcess.Enqueue);
        }
    }
}