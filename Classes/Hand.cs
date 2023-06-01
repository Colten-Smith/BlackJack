using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.Classes
{
    public class Hand
    {


        //################################
        //PROPERTIES
        //################################


        //list Cards in Hand
        /// <summary>
        /// Stores a list of the cards in the hand
        /// </summary>
        public List<Card> Cards { get; private set; }
            //int Amount of Cards
        /// <summary>
        /// Stores the number of Cards in the Hand.
        /// </summary>
        public int AmountOfCards
        {
            get
            {
                int output = 0;
                foreach(Card item in Cards)
                {
                    output++;
                }return output;
            }
        }
        //----------


        //################################
        //CONSTRUCTOR
        //################################


        /// <summary>
        /// Creates a new hand of Cards.
        /// </summary>
        /// <param name="cards">List of Cards in the Hand</param>
        public Hand(List<Card> cards)
        {
            Cards = cards;
        }

        //-----------


        //################################
        //METHODS
        //################################


            //public void ShowCard : Sets all Cards in Hand to face up
        /// <summary>
        /// Sets all Cards in Hand to Face Up.
        /// </summary>
        public void ShowCard()
        {
            foreach(Card card in Cards)
            {
                card.Flip(false);
            }
        }
            //HideCard : Sets all Cards to face Down
        /// <summary>
        /// Sets all Cards in Hand to Face Down.
        /// </summary>
        public void HideCard()
        {
            foreach(Card card in Cards)
            {
                card.Flip(true);
            }
        }
            //ShowCard(int cardIndex) : Sets Specific card to face up
        /// <summary>
        /// Sets a specific Card to Face Up
        /// </summary>
        /// <param name="cardIndex">Index of the specific Card in the Hand to Flip</param>
        public void ShowCard(int cardIndex)
        {
            if (Cards[cardIndex] != null)
            {
                Cards[cardIndex].Flip(false);
            }
        }
            //HideCard(int cardIndex) : Sets Specific card to face down
        /// <summary>
        /// Sets a specific Card to Face Down
        /// </summary>
        /// <param name="cardIndex">Index of the specific Card in the Hand to flip</param>
        public void HideCard(int cardIndex)
        {
            if (Cards[cardIndex] != null)
            {
            Cards[cardIndex].Flip(true);
            }
        }
            //SortCard : Sorts the cards in by suit and rank
        /// <summary>
        /// Sorts the Cards in the Hand into the default order.
        /// </summary>
        public void SortCard()
        {
            //Sorts By Suit first(D, C, H, S), then by rank. (A-10, J, Q, K)
            List<Card> diamonds = new List<Card>();
            List<Card> clubs = new List<Card>();
            List<Card> hearts = new List<Card>();
            List<Card> spades = new List<Card>();
            foreach (Card card in Cards)
            {
                if (card.Suit.ToLower() == "diamonds")
                {
                    diamonds.Add(card);
                }
                else if (card.Suit.ToLower() == "clubs")
                {
                    clubs.Add(card);
                }
                else if (card.Suit.ToLower() == "hearts")
                {
                    hearts.Add(card);
                }
                else
                {
                    spades.Add(card);
                }
            }
            bool switched = true;
            while (switched)
            {
                switched = false;
                for (int i = 0; i < diamonds.Count - 1; i++)
                {
                    if (diamonds[i].Rank > diamonds[i + 1].Rank)
                    {
                        Card tempCard = diamonds[i];
                        diamonds[i] = diamonds[i + 1];
                        diamonds[i + 1] = tempCard;
                        switched = true;
                    }
                }
            }
            switched = true;
            while (switched)
            {
                switched = false;
                for (int i = 0; i < clubs.Count - 1; i++)
                {
                    if (clubs[i].Rank > clubs[i + 1].Rank)
                    {
                        Card tempCard = clubs[i];
                        clubs[i] = clubs[i + 1];
                        clubs[i + 1] = tempCard;
                        switched = true;
                    }
                }
            }
            switched = true;
            while (switched)
            {
                switched = false;
                for (int i = 0; i < hearts.Count - 1; i++)
                {
                    if (hearts[i].Rank > hearts[i + 1].Rank)
                    {
                        Card tempCard = hearts[i];
                        hearts[i] = hearts[i + 1];
                        hearts[i + 1] = tempCard;
                        switched = true;
                    }
                }
            }
            switched = true;
            while (switched)
            {
                switched = false;
                for (int i = 0; i < spades.Count - 1; i++)
                {
                    if (spades[i].Rank > spades[i + 1].Rank)
                    {
                        Card tempCard = spades[i];
                        spades[i] = spades[i + 1];
                        spades[i + 1] = tempCard;
                        switched = true;
                    }
                }
            }
            Cards.RemoveRange(0, Cards.Count);
            Cards.AddRange(diamonds);
            Cards.AddRange(clubs);
            Cards.AddRange(hearts);
            Cards.AddRange(spades);
        }
        //SortCard(int cardToMove, int cardNewPosition)
        /// <summary>
        /// Moves a Card at a specified valid index to a new valid index.
        /// </summary>
        /// <param name="cardIndex">Index of the Card to Move.</param>
        /// <param name="cardNewIndex">Index to move the Card to.</param>
        public void SortCard(int cardIndex, int cardNewIndex)
        {
            if (Cards[cardIndex] != null && Cards[cardNewIndex] != null && cardNewIndex != cardIndex)
            {
                //Make a copy of the card you want to move
                Card tempCard = Cards[cardIndex];
                //Move the damn card
                if (cardIndex < cardNewIndex)
                {
                    Cards.Insert(cardNewIndex + 1, tempCard);
                    Cards.RemoveAt(cardIndex);
                }
                else
                {
                    Cards.Insert(cardNewIndex, tempCard);
                    Cards.RemoveAt(cardIndex + 1);
                }

            }
        }
            //SwapCard
        /// <summary>
        /// Switches the positions of two Cards at specified valid indexes.
        /// </summary>
        /// <param name="indexOne">Index of one of the Cards being swapped.</param>
        /// <param name="indexTwo">Index of one of the Cards being swapped.</param>
        public void SwapCard(int indexOne, int indexTwo)
        {
            if (Cards[indexOne] != null && Cards[indexTwo] != null)
            {
                Card tempCard = Cards[indexOne];
                Cards[indexOne] = Cards[indexTwo];
                Cards[indexTwo] = tempCard;
            }
        }
            //Discard : Discards card at index 0, if any
        /// <summary>
        /// Discards the first Card in the Hand.
        /// </summary>
        /// <returns>Returns the discarded Card, or null if the hand is empty.</returns>
        public Card Discard()
        {
            if (Cards[0] != null)
            {
                Card output = Cards[0];
                Cards.RemoveAt(0);
                return output;
            }
            return null;
        }
            //Discard(int cardIndex)
        /// <summary>
        /// Discards the card at a specified valid index.
        /// </summary>
        /// <param name="cardIndex">Index of the card to be discarded.</param>
        /// <returns>Returns the discarded Card, or null if the index is not valid.</returns>
        public Card Discard(int cardIndex)
        {
            if (Cards[cardIndex] != null)
            {
                Card output = Cards[cardIndex];
                Cards.RemoveAt(cardIndex);
                return output;
            }
            return null;
        }
            //Add Card (Card cardToAdd)
        /// <summary>
        /// Adds a Card to the Hand.
        /// </summary>
        /// <param name="cardToAdd">Card to be added to the Hand.</param>
        public void AddCard(Card cardToAdd)
        {
            if (cardToAdd != null)
            {
            Cards.Add(cardToAdd);
            }
        }

        //GetValue()
        public int GetValue()
        {
            int value = 0;
            foreach(Card item in Cards)
            {
                value += item.Rank;
            }
            return value;
        }
        //GetValue(int aceValue)
        public int GetValue(int aceValue, int faceValue)
        {
            int value = 0;
            foreach(Card item in Cards)
            {
                if(item.Rank == 1)
                {
                    value += aceValue;
                }
                else if(item.Rank > 10)
                {
                    value += faceValue;
                }
                else
                {
                    value += item.Rank;
                }
            }
            return value;
        }
        //GetValue(int aceValue, int faceValue, int overlap)
        public int GetValue(int aceValue, int faceValue, int overlap)
        {
            int value = 0;
            int aces = 0;
            foreach (Card item in Cards)
            {
                if (item.Rank == 1)
                {
                    value += aceValue;
                    aces += 1;
                }
                else if (item.Rank > 10)
                {
                    value += faceValue;
                }
                else
                {
                    value += item.Rank;
                }
                while (value > overlap && aces > 0)
                {
                    value-= aceValue - 1;
                    aces -= 1;
                }
            }
            return value;
        }
        public List<string> GetHandArt()
        {
            List<string> output = new List<string>();
            for (int i = 0; i < 9; i++)
            {
                string line = "";
                foreach (Card card in Cards)
                {
                    line += card.GetArt()[i];
                }
                output.Add(line);
            }
            /*Create a new List where each element in the list is the sum of all of the elements in the same index in each card in Cards
             */

            return output;
        }
        //-----------
    }
}