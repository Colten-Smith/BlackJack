using BlackJack.Classes;
using BlackJack_1._0.Classes;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;

//###################################################
//                       LOG
/*###################################################
Imported Deck and Card classes.
Created isComplete loop.
Began Hand class.
Created BlackJackUI class
Created Dealer class
Completed one of the Sort Methods in the Hand class
Created the discard class
Completed sorting methods for the Hand class
Renamed BlackJackUI to ConsoleUI
Made Progress on ConsoleUI class
Completed ConsoleUI class
Completed user turn program
*/


namespace BlackJack
{
    internal class Program
    {
        static void Main(string[] args)
        {

            

            bool isComplete = false;
            List<string> hud = new List<string>();
            ChipBank playerChips = new ChipBank(50);
            ////Create the Title and Description
            List<string> title = new List<string>();
            title.Add("  ____  _            _        _            _    ");
            title.Add(" |  _ \\| |          | |      | |          | |   ");
            title.Add(" | |_) | | __ _  ___| | __   | | __ _  ___| | __");
            title.Add(" |  _ <| |/ _` |/ __| |/ /   | |/ _` |/ __| |/ /");
            title.Add(" | |_) | | (_| | (__|   < |__| | (_| | (__|   < ");
            title.Add(" |____/|_|\\__,_|\\___|_|\\_\\____/ \\__,_|\\___|_|\\_\\");

            List<string> description = new List<string>();
            description.Add("Description and Rules:");
            description.Add("BlackJack is a game where you get a hand of cards, and want the sum of the cards values to be higher than the dealer.");
            description.Add("Number Cards are worth their rank, Face Cards are worth 10, and Aces are worth either 11 or 1.");
            description.Add("If the sum of your cards goes over 21, you automatically lose.");

            //Create the UI
            ConsoleUI ui = new ConsoleUI(title, description);
                
            //Display the Title to the screen
            ui.DisplayTitle();
            ui.DisplayDescription();
            ui.Blank("Press Enter to start: > ");
            ui.Reset();

            //Create to run while not complete
            while (!isComplete)
            {
                bool playerBust = false;
                bool dealerBust = false;
                Deck deck = new Deck();
                deck.Shuffle();
                Hand dealer = new Hand(deck.Draw(2));
                Hand player = new Hand(deck.Draw(2));
                ui.Display();
                int playerValue = player.GetValue(11, 10, 21);
                bool turnOver = false;
                int dealerValue = dealer.GetValue(11, 10, 21);
                bool dealerOver = false;
                ui.AddHUD($"Your Chips: {playerChips.NumberOfChips}");
                ui.Display($"Your Chips: {playerChips.NumberOfChips}");
                bool betValid = playerChips.Bet(int.Parse(ui.GetUserInput("How many chips do you want to bet?", true, "int")));
                while (!betValid)
                {
                    ui.Reset();
                    betValid = playerChips.Bet(int.Parse(ui.GetUserInput("Invalid bet, try again:", true, "int")));
                    hud.Add($"Your Chips: {playerChips.NumberOfChips}");
                    hud.RemoveAt(0);
                    ui.setHUD(hud);
                }
                ui.Reset();
                //Create a loop to run while turnOver = false and while the hand is worth less than 21
                while (!turnOver && playerValue < 21)
                {
                    //In the loop
                    //Display the player's stats
                    ui.Display("Your Chips: "+playerChips.NumberOfChips);
                    ui.DisplayBorder();
                    ui.Display();
                    ui.Display("Your Cards:");
                    ui.DisplayBorder();
                    ui.Display(player.GetHandArt());
                    ui.Display("");
                    ui.Display($"Current hand is {playerValue}.");
                    ui.DisplayBorder();

                    //Ask the user if they want another card
                    if (ui.GetUserInput("Want another card?", true, "bool") == "n")
                    {
                        turnOver = true;
                    }
                    else
                    {
                        player.AddCard(deck.Draw());
                        playerValue = player.GetValue(11, 10, 21);
                        ui.Reset();
                    }
                    ui.Display();
                    //If so ,give them another card from the deck.
                    //If not, set turnover to true.
                    //Reset the playerValue
                }

                //Display the user's final hand
                ui.Reset();
                ui.Display();
                ui.Display();
                ui.Display("Your Cards:");
                ui.DisplayBorder();
                ui.Display(player.GetHandArt());
                ui.Display("");
                ui.Display($"Final hand is {playerValue}.");

                //Check the result of their hand
                if (playerValue == 21)
                {
                    ui.Display("BlackJack!");
                }
                else if (playerValue > 21)
                {
                    ui.Display("Bust!");
                    playerBust = true;
                }
                ui.DisplayBorder();
                ui.Display();
                //Dealer's turn
                while (!dealerOver && dealerValue < 21)
                {
                    //In the loop
                    //Display the player's stats

                    //Ask the user if they want another card
                    if (dealerValue >= 17)
                    {
                        dealerOver = true;
                    }
                    else
                    {
                        dealer.AddCard(deck.Draw());
                        dealerValue = dealer.GetValue(11, 10, 21);
                    }
                    //If so ,give them another card from the deck.
                    //If not, set turnover to true.
                    //Reset the playerValue
                }
                if (dealerValue > 21)
                {
                    dealerBust = true;
                }
                ui.Display();
                ui.Display("Dealer's Cards.");
                ui.DisplayBorder();
                ui.Display(dealer.GetHandArt());
                ui.Display("");
                ui.Display($"Dealer hand is {dealerValue}.");
                ui.DisplayBorder();
                ui.Display();
                ui.Display();

                if (!playerBust && (dealerBust || playerValue > dealerValue))
                {
                    ui.Display("You Win!");
                    playerChips.Win();
                }
                else if ((playerValue == dealerValue) || (playerBust && dealerBust)){
                    ui.Display("You tied!");
                    playerChips.Tie();
                }
                else
                {
                    ui.Display("Sorry, You Lost.");
                    playerChips.Lose();
                }



                //Ask the user if they want to play again.
                ui.Display("Your Chips: " + playerChips.NumberOfChips);
                if (playerChips.NumberOfChips > 0)
                {
                    if (ui.GetUserInput("Play Again?", true, "string").Trim().ToLower().StartsWith('n')){
                        ui.DisplayBorder();
                        isComplete = true;
                    }
                    else
                    {
                        ui.Reset();
                    }
                }
                else
                {
                    ui.Display("Bankrupt!");
                    isComplete = true;
                }
                
                
            }
        }
    }
}