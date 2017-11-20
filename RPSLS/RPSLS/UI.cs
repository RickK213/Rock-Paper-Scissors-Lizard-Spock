﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPSLS
{
    public static class UI
    {
        //member variables
        public static List<string> gameVariables = new List<string>() { "Rock", "Paper", "Scissors", "Spock", "Lizard" };

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
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("WELCOME TO ROCK, PAPER, SCISSORS, SPOCK, LIZARD\n");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("RULES:");
            Console.ResetColor();
            Console.WriteLine("This game is an expansion on the game Rock, Paper, Scissors.\n\nDuring each round, each player picks a variable by pressing keys 0-4:");
            DisplayPlayerMenu();
            Console.WriteLine("\nThe winner of each round is the player who defeats the other.\nIn a tie, the process is repeated until a round winner is found.\nThe first player to achieve best of three wins the game.\n");
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
            Console.ResetColor();
        }

        public static int GetGameModeOption()
        {
            DisplayGameModeOptions();
            string userSelection = GetUserSelectionKey();
            if (!(userSelection == "1" || userSelection == "2"))
            {
                Console.Clear();
                return GetGameModeOption();
            }
            return int.Parse(userSelection);
        }

        public static void DisplayPlayerInterface(Player player)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("{0}: Select your variable:", player.name);
        }

        public static void DisplayPlayerSelection(Player player)
        {
            Console.WriteLine("{0} selected {1}", player.name, UI.gameVariables[player.currentSelection]);
        }

        //(and as it always has) Rock crushes Scissors

        public static string GetDefeatWord(string winnerWord, string loserWord)
        {
            string defeatWord = " defeats ";
            if ((winnerWord == "Scissors") && (loserWord == "Paper"))
            {
                defeatWord = "cuts";
            }
            else if ((winnerWord == "Paper") && (loserWord == "Rock"))
            {
                defeatWord = "covers";
            }
            else if ((winnerWord == "Rock") && (loserWord == "Lizard"))
            {
                defeatWord = "crushes";
            }
            else if ((winnerWord == "Lizard") && (loserWord == "Spock"))
            {
                defeatWord = "poisons";
            }
            else if ((winnerWord == "Spock") && (loserWord == "Scissors"))
            {
                defeatWord = "smashes";
            }
            else if ((winnerWord == "Scissors") && (loserWord == "Lizard"))
            {
                defeatWord = "decapitates";
            }
            else if ((winnerWord == "Lizard") && (loserWord == "Paper"))
            {
                defeatWord = "eats";
            }
            else if ((winnerWord == "Paper") && (loserWord == "Spock"))
            {
                defeatWord = "disproves";
            }
            else if ((winnerWord == "Spock") && (loserWord == "Rock"))
            {
                defeatWord = "vaporizes";
            }
            else if ((winnerWord == "Rock") && (loserWord == "Scissors"))
            {
                defeatWord = "blunts";
            }

            return defeatWord;
        }

        public static void DisplayRoundOutcome(Player winner, Player loser, bool isTie)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("");
            if ( isTie )
            {
                Console.WriteLine("{0} and {1} Tie The Round.",winner.name, loser.name);
            }
            else
            {
                string defeatWord = UI.GetDefeatWord(gameVariables[winner.currentSelection], gameVariables[loser.currentSelection]);
                Console.WriteLine("{0} {1} {2}", gameVariables[winner.currentSelection], defeatWord, gameVariables[loser.currentSelection]);
                Console.WriteLine("{0} Wins The Round!", winner.name);
            }
            Console.ResetColor();
        }

        public static void DisplayNumberOfWins(Player player1, Player player2)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n{0} has {1} wins. {2} has {3} wins.", player1.name, player1.numberOfWins, player2.name, player2.numberOfWins);
            Console.ResetColor();
        }

        public static void GetAnyKeyToContinue()
        {
            Console.WriteLine("\nPress any key to continue.");
            Console.ReadKey();
            Console.Clear();
        }

        public static void DisplayWinner(string gameWinnerName)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n{0} WINS THE GAME!", gameWinnerName);
            Console.ResetColor();
        }

        private static void DisplayPlayAgainOption()
        {
            Console.WriteLine("\nWould you like to play again?");
            Console.Write("Press '");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("y");
            Console.ResetColor();
            Console.Write("' or '");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("n");
            Console.ResetColor();
            Console.WriteLine("'");
        }

        private static string GetUserSelectionKey()
        {
            string userSelection = Console.ReadKey(true).KeyChar.ToString();
            return userSelection;
        }

        public static bool getPlayAgainOption()
        {
            DisplayPlayAgainOption();
            string playAgainOption = GetUserSelectionKey();
            if (!(playAgainOption == "y" || playAgainOption == "n"))
            {
                Console.Clear();
                getPlayAgainOption();
            }
            if ( playAgainOption  == "y" )
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
