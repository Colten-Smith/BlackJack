using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack_1._0.Classes
{
    public class Card
    {
        // removing the setter (set;), this value can only be set through the constuctor
        // It cannot be changed
        /// <summary>
        /// This holds the suit of the card
        /// </summary>
        public string Suit { get; }
        /// <summary>
        /// This is the rank or value of the card
        /// </summary>
        public int Rank { get; }

        // color is a derived property
        // the color is derived from the suit
        /// <summary>
        /// This is the color of the card
        /// </summary>
        public string Color
        {
            get
            {
                if(Suit == "Hearts" || Suit == "Diamonds")
                {
                    return "Red";
                }
                else
                {
                    return "Black";
                }
            }
        }

        // this means anyone can get the value, but it can only be set within the object
        /// <summary>
        /// Is the card face up or face down.
        /// </summary>
        public bool IsFaceUp { get; private set; } = true;

        public char SuitSymbol
        {
            get
            {
                return suitSymbols[Suit];
            }
        }
        public string FaceValue
        {
            get
            {
                return faceValues[Rank];
            }
        }
        public string Name
        {
            get
            {
                return $"{FaceValue} of {Suit}{SuitSymbol}";
            }
        }
        private List<string> FaceArt
        {
            get
            {
                List<string> output = new List<string>();
                output.Add("┌─────────┐");
                if (Rank < 10 && Rank > 1)
                {
                    output.Add($"│{Rank}        │");
                }else if (Rank == 10)
                {
                    output.Add($"│{Rank}       │");
                }
                else
                {
                    output.Add($"│{FaceValue[0]}        │");
                }
                output.Add($"│         │");
                output.Add($"│         │");
                output.Add($"│    {SuitSymbol}    │");
                output.Add($"│         │");
                output.Add($"│         │");
                if (Rank < 10 && Rank > 1)
                {
                    output.Add($"│        {Rank}│");
                }
                else if (Rank == 10)
                {
                    output.Add($"│       {Rank}│");
                }
                else
                {
                    output.Add($"│        {FaceValue[0]}│");
                }
                output.Add($"└─────────┘");
                return output;
            }
        }
        private List<string> BackArt
        {
            get
            {
                List<string> output = new List<string>();

                return output;
            }
        }

        // custom constructor -- forces the caller to give the necessary data
        // cannot have a blank card
        /// <summary>
        /// Create a new playing card
        /// </summary>
        /// <param name="suit">The suit of the card</param>
        /// <param name="rank">The rank of the card</param>
        public Card(string suit, int rank)
        {
            Suit = suit;
            Rank = rank;
        }
        // overload constructor
        public Card(string Suit, int Rank, bool isFaceUp)
        {
            this.Suit = Suit;
            this.Rank = Rank;
            this.IsFaceUp = IsFaceUp;
        }

        /// <summary>
        /// Flips the card over
        /// </summary>
        /// <returns></returns>
        public bool Flip()
        {
            if(IsFaceUp)
            {
                IsFaceUp = false;
            }
            else
            {
                IsFaceUp = true;
            }
            return IsFaceUp;
        }
        // This is called an overload method
        // This allows the caller to specify if the card should be face down or face up
        /// <summary>
        /// Flips the card to the state specified by the user.
        /// </summary>
        /// <param name="shouldBeFaceDown"></param>
        /// <returns></returns>
        public bool Flip(bool shouldBeFaceDown)
        {
            if(shouldBeFaceDown)
            {
                IsFaceUp = false;
            }
            else
            {
                IsFaceUp = true;
            }
            return IsFaceUp;
        }
        public List<string> GetArt()
        {
            if (IsFaceUp)
            {
                return FaceArt;
            }return BackArt;
        }
        public static Dictionary<string, char> suitSymbols = new Dictionary<string, char>()
        {
            {"Spades",'\u2660' },
            {"Diamonds",'\u2666' },
            {"Clubs",'\u2663' },
            {"Hearts",'\u2665' }
        };

        private Dictionary<int, string> faceValues = new Dictionary<int, string>()
        {
            {1,"Ace" },
            {2, "Two" },
            {3, "Three" },
            {4, "Four" },
            {5,"Five" },
            {6, "Six" },
            {7, "Seven" },
            {8, "Eight" },
            {9, "Nine" },
            {10, "Ten" },
            {11, "Jack" },
            {12, "Queen" },
            {13, "King" }
        };
    }
}
