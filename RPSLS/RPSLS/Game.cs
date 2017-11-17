using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPSLS
{
    public class Game
    {

        //Task:
        //Rock Paper Scissors Lizard Spock
        //Write a program that provides the game play of RPSLS
        //The game must include options to play against a human or an AI(both options must be present)
        //The game must be best of three
        //Use best practices

        //member variables
        public bool isGameOver = false;
        public bool isTwoPlayer = false;
        public int currentRound = 1;
        public int currentPlayer = 1;
        public Player player1;
        public Player player2;


        //constructor


        //member methods
        public void DisplayPlayerMenu()
        {
            List<string> gameVariables = new List<string>() {"Rock", "Paper", "Scissors", "Lizard", "Spock"};
            for (int i=0; i < gameVariables.Count(); i++)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(i);
                Console.ResetColor();
                Console.Write(" = ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(gameVariables[i]);
                if( i < gameVariables.Count()-1 )
                {
                    Console.ResetColor();
                    Console.Write("  |  ");
                }
            }
            Console.ResetColor();
        }

        private void DisplayInstructions()
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

        public void DisplayGameModeOptions()
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

        private int GetGameModeOption()
        {
            string userSelection = Console.ReadKey(true).KeyChar.ToString();
            if ( !(userSelection == "1" || userSelection == "2") )
            {
                GetGameModeOption();
            }
            return int.Parse(userSelection);
        }

        private void SetGameMode(int gameMode)
        {
            if (gameMode == 2)
            {
                isTwoPlayer = true;
            }
        }

        public void StartGame()
        {
            DisplayInstructions();
            DisplayGameModeOptions();
            int gameMode = GetGameModeOption();
            SetGameMode(gameMode);
            PlayRounds();
        }

        private void SetUpGame()
        {
            player1 = new HumanPlayer();
            if ( isTwoPlayer )
            {
                player2 = new HumanPlayer();
            }
            else
            {
                player2 = new ComputerPlayer();
            }
        }

        private void PlayRound()
        {

        }

        private void PlayRounds()
        {
            Console.Clear();
            SetUpGame();
            while ( !isGameOver )
            {
                PlayRound();
            }
        }
    }
}
