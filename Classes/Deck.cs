using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack_1._0.Classes
{
    public class Deck
    {
        public int AmountOfCards
        {
            get
            {
                return Cards.Count;
            }
        }
        private List<Card> Cards { get; set; } = new List<Card>();

        public Deck()
        {
            // don't need this because the instantiation is on line 12
            // Cards = new List<Card>();
            foreach(string suit in Card.suitSymbols.Keys)
            {
                for(int i = 1; i <= 13; i++)
                {
                    Card c = new Card(suit, i);
                    Cards.Add(c);

                }
            }
        }

        public Card Draw()
        {
            Card cardDrawn = null;
            // only draw a card if there are cards in the deck
            if (Cards.Count > 0)
            {
                // draw the first card
                cardDrawn = Cards[0];
                // remove the card from the deck
                Cards.RemoveAt(0);
            }
            // return the card or null if no more cards in my deck
            return cardDrawn;
        }
        public List<Card> Draw(int toDraw)
        {
            List<Card> cardsDrawn = new List<Card>();
            // only draw cards if there are enough cards in the deck
            if (Cards.Count >= toDraw)
            {
                while (toDraw > 0)
                {
                    // draw the first card
                    cardsDrawn.Add(Cards[0]);
                    // remove the card from the deck
                    Cards.RemoveAt(0);
                    toDraw--;
                }
            }
            // return the card or null if no more cards in my deck
            return cardsDrawn;
        }

        public void Shuffle()
        {
            Random r = new Random();
            for(int i = 0; i < 1000000; i++)
            {
                int firstPosition = r.Next(AmountOfCards);
                int secondPosition = r.Next(AmountOfCards);
                // hold on to this so it isn't lost
                Card temp = Cards[firstPosition];
                Cards[firstPosition] = Cards[secondPosition];
                Cards[secondPosition] = temp;
            }
        }
    }
}
