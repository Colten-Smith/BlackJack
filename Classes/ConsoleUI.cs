using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
namespace BlackJack.Classes
{
    public class ConsoleUI
    {
        //################################
        //          PROPERTIES
        //################################

        //Title {get; set;}
        /// <summary>
        /// Stores the title of the program, with each item in the list being on a new line.
        /// </summary>
        public List<string> Title { get; private set; }

        //Description {get; set}
        /// <summary>
        /// Stores the description of the program, with each item in the list being on a new line.
        /// </summary>
        public List<string> Description { get; private set; }

        //Hud {get;set;}
        public List<string> HUD { get; private set; } = new List<string>();
        //Border
        //String used as a border between sections of the program.
        public string Border { get; private set; } = "=========================================================================================================" +
            "============================";

        //################################



        //################################
        //         CONSTRUCTOR
        //################################

        /// <summary>
        /// Generates elements that interact with the user through the console.
        /// </summary>
        /// <param name="title">The title of the program, with each line being a new element in the list.</param>
        /// <param name="description">The description of the program, with each line being a new element in the list.</param>
        public ConsoleUI(List<string> title, List<string> description)
        {
            Title = title;
            Description = description;
            Console.Write(Border);
        }
        public ConsoleUI(List<string> title, List<string> description, List<string> hud)
        {
            Title = title;
            Description = description;
            HUD = hud;
            Console.Write(Border);
        }

        //################################



        //################################
        //          METHODS
        //################################

        //GetUserInput(string display, bool validate)

        /// <summary>
        /// Get's the user's input given a prompt, with the option to validate the input as the proper data type. Always returns a lowercase result.
        /// </summary>
        /// <param name="display">Text to display to the user as a prompt or question.</param>
        /// <param name="validate">Decides whether or not the user's input should go through data validation.</param>
        /// <param name="type">The data type you want the input to be, in the form of a string. If the data type is bool, the output will be either "y" or "n"</param>
        /// <returns></returns>
        public string GetUserInput(string display, bool validate, string type)
        {
            Console.Write("|" + display + " > ");
            string userInput = Console.ReadLine();
            if (validate)
            {
                while (true)
                {
                    if (userInput == null || userInput == "")
                    {
                        Reset();
                        Console.Write("|Invalid entry, please try again: > ");
                        userInput = Console.ReadLine();
                    }
                    else if (type.Trim().ToLower().Substring(0, 3) == "int")
                    {
                        if (int.TryParse(userInput, out int result))
                        {
                            return userInput.Trim().ToLower();
                        }
                        else
                        {
                            Reset();
                            Console.Write("|Invalid entry, please enter an integer: > ");
                            userInput = Console.ReadLine();
                        }
                    }else if (type.Trim().Length >= 6 && type.Trim().ToLower().Substring(0, 6) == "double")
                    {
                        if (double.TryParse(userInput, out double result))
                        {
                            return userInput.Trim().ToLower();
                        }
                        else
                        {
                            Reset();
                            Console.Write("|Invalid entry, please enter an decimal value: > ");
                            userInput = Console.ReadLine();
                        }
                    }
                    else if (type.Trim().ToLower().Substring(0, 4) == "bool")
                    {
                        if (userInput.Trim().ToLower()[0] == 'y' || userInput.Trim().ToLower()[0] == 'n')
                        {
                            return userInput.Trim().ToLower().Substring(0, 1);
                        }
                        else
                        {
                            Reset();
                            Console.Write("|Invalid entry, please enter either Yes or No: > ");
                            userInput = Console.ReadLine();
                        }
                    }
                    else
                    {
                        return userInput.Trim().ToLower();
                    }
                }
            }return userInput;
        }

        //DisplayTitle

        /// <summary>
        /// Displays the title on the screen, center indexed.
        /// </summary>
        public void DisplayTitle()
        {
            foreach (string line in Title)
            {
                int tempNum = Border.Length / 2 - 1 - line.Length / 2;
                string buffer = "";
                for (int i = tempNum; i > 0; i--) {
                    buffer += " ";
                }
                Console.Write("|" + buffer + line);
                if (line.Length / 2 == 1)
                {
                    Console.Write(buffer + "  |");
                }else Console.Write(buffer + " |");
            }
            Console.Write(Border);
        }
        
        //DisplayBorder()

        /// <summary>
        /// Puts a border on the screen to divide up sections of the user's interface.
        /// </summary>
        public void DisplayBorder()
        {
            Console.Write(Border);
        }
        /// <summary>
        /// Writes a blank line to the screen.
        /// </summary>
        public void Display()
        {
            Console.WriteLine();
        }
        //Display(string output)
        /// <summary>
        /// Displays the input string to user, left indexed.
        /// </summary>
        /// <param name="output">The string to be displayed.</param>
        public void Display(string output)
        {
            Console.WriteLine("|" + output);
        }

        //Display(List<string> outputs)
        /// <summary>
        /// Displays the input strings from the list to the user, with each item being on a new line.
        /// </summary>
        /// <param name="outputs">The list containing the strings to be displayed.</param>
        public void Display(List<string> outputs)
        {
            foreach(string item in outputs)
            {
                Console.WriteLine("|" + item);
            }
        }

        //DisplayDescription

        /// <summary>
        /// Displays the description of the program.
        /// </summary>
        public void DisplayDescription()
        {
            foreach (string line in Description)
            {
                int tempNum = Border.Length - (2 + line.Length);
                string buffer = "";
                for (int i = tempNum; i > 0; i--)
                {
                    buffer += " ";
                }
                Console.Write("|" + line);
                Console.Write(buffer + "|");
            }
            Console.Write(Border);
        }
        public void Clear()
        {
            Console.Clear();
        }
        public void Reset()
        {
            Console.Clear();
            DisplayBorder();
            DisplayTitle();
            DisplayHUD();
        }
        public void Blank()
        {
            Console.ReadLine();
        }
        public void Blank(string prompt)
        {
            Console.Write($"| {prompt}");
            Console.ReadLine();
        }
        public void setHUD(List<string> newHud)
        {
            HUD = newHud;
        }
        public void AddHUD(string newElement)
        {
            HUD.Add(newElement);
        }
        public void AddHUD(List<string> newElements)
        {
            HUD.AddRange(newElements);
        }
        public void DisplayHUD()
        {
            foreach (string line in HUD)
            {
                int tempNum = Border.Length - (2 + line.Length);
                string buffer = "";
                for (int i = tempNum; i > 0; i--)
                {
                    buffer += " ";
                }
                Console.Write("|" + line);
                Console.Write(buffer + "|");
            }
        }
        //################################

    }
}
