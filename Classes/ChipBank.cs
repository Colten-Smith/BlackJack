using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack_1._0.Classes
{
    public class ChipBank
    {
        //todo create chip bank class

        /*
         ###########################
                 PROPERTIES
         ###########################
        */
        
        //Amount of chips (private set)
        public int NumberOfChips { get; private set; }

        //Chips to bet (private set)
        public int ChipsToBet { get; private set; } = 0;
        //Has bet (private set)
        private bool CanBet {get; set; } = true;
        /*
         ###########################
                CONSTRUCTOR
         ###########################
        */
        
        //Amount of Chips
        public ChipBank(int numberOfChips)
        {
            NumberOfChips = numberOfChips;
        }

        /*
         ###########################
                  METHODS
         ###########################
        */
        
        //Bet(int chipsToBet)
        public bool Bet(int chipsToBet)
        {
            if (CanBet && chipsToBet <= NumberOfChips && chipsToBet >= 0)
            {
                ChipsToBet = chipsToBet;
                NumberOfChips -= chipsToBet;
                CanBet = false;
                return true;
            }
            return false;
        }

        //Win()
        public void Win()
        {
            if (!CanBet)
            {
                NumberOfChips += ChipsToBet * 2;
                ChipsToBet = 0;
                CanBet = true;
            }
        }

        //Lose()
        public void Lose()
        {
            if (!CanBet)
            {
                ChipsToBet = 0;
                CanBet = true;
            }
        }

        //Tie()
        public void Tie()
        {
            if (!CanBet)
            {
                NumberOfChips += ChipsToBet;
                ChipsToBet = 0;
                CanBet = true;
            }
        }

    }
}
