using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPSLS
{
    public static class UI
    {
        //member variables
        public static Random randomNumber = new Random();
        public static List<string> gameVariables = new List<string>() { "Rock", "Paper", "Scissors", "Lizard", "Spock" };

        //member methods
        public static void DisplayPlayerMenu()
        {
            for (int i = 0; i < gameVariables.Count(); i++)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(i);
                Console.ResetColor();
                Console.Write(" = ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(gameVariables[i]);
                if (i < gameVariables.Count() - 1)
                {
                    Console.ResetColor();
                    Console.Write("  |  ");
                }
            }
            Console.ResetColor();
            Console.WriteLine("\n");
        }

        public static void DisplayInstructions()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("WELCOME TO ROCK, PAPER, SCISSORS, LIZARD, SPOCK\n");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("RULES:");
            Console.ResetColor();
            Console.WriteLine("This game is an expansion on the game Rock, Paper, Scissors.\n\nDuring each round, each player picks a variable by pressing keys 0-4:");
            DisplayPlayerMenu();
            Console.WriteLine("\n\nThe winner of each round is the player who defeats the other.\nIn a tie, the process is repeated until a round winner is found.\nThe first player to achieve best of three wins the game.\n");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("DURING EACH ROUND:");
            Console.ResetColor();
            Console.WriteLine("Scissors cuts Paper\nPaper covers Rock\nRock crushes Lizard\nLizard poisons Spock\nSpock smashes Scissors\nScissors decapitates Lizard\nLizard eats Paper\nPaper disproves Spock\nSpock vaporizes Rock\nRock crushes Scissors");
        }

        public static void DisplayGameModeOptions()
        {
            Console.Write("\nPress ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("1");
            Console.ResetColor();
            Console.Write(" for ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("1-Player Mode");
            Console.ResetColor();
            Console.Write(" or ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("2");
            Console.ResetColor();
            Console.Write(" for ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("2-Player Mode");
        }

        public static int GetGameModeOption()
        {
            string userSelection = Console.ReadKey(true).KeyChar.ToString();
            if (!(userSelection == "1" || userSelection == "2"))
            {
                GetGameModeOption();
            }
            return int.Parse(userSelection);
        }

        public static void DisplayPlayerInterface(Player player)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("{0}: Select your variable:", player.name);
        }

        public static void DisplayRoundResults(Player player)
        {
            Console.WriteLine("{0} selected {1}", player.name, UI.gameVariables[player.currentSelection]);
        }

    }
}
