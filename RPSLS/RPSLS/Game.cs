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
        public bool isGameOver;
        public bool isTwoPlayerMode;
        public Player player1;
        public Player player2;
        public int numberOfWinsToWinGame = 2;
        public int d;

        //constructor


        //member methods
        private void SetGameMode(int gameMode)
        {
            if (gameMode == 2)
            {
                isTwoPlayerMode = true;
            }
        }

        public void StartGame()
        {
            UI.DisplayInstructions();
            int gameMode = UI.GetGameModeOption();
            SetGameMode(gameMode);
            PlayRounds();
        }

        private void SetUpGame()
        {
            isGameOver = false;

            player1 = new HumanPlayer();
            player1.numberOfWins = 0;

            if ( isTwoPlayerMode )
            {
                player2 = new HumanPlayer();
                player2.name = "Player 2";
                player2.numberOfWins = 0;
            }
            else
            {
                player2 = new ComputerPlayer();
                player2.numberOfWins = 0;
            }
        }

        private void setNumberOfWins(Player player1, Player player2)
        {
            d = (5 + player1.currentSelection - player2.currentSelection) % 5;
            if (d == 0)
            {
                UI.DisplayRoundOutcome(player1, player2, true);
            }
            else if (d == 1 || d == 3)
            {
                UI.DisplayRoundOutcome(player1, player2, false);
                player1.numberOfWins++;
            }
            else if (d == 2 || d == 4)
            {
                UI.DisplayRoundOutcome(player2, player1, false);
                player2.numberOfWins++;
            }
            else
            {
                Console.WriteLine("Game error.");
            }
        }

        private void PlayRound()
        {
            player1.SetVariableSelection();
            player2.SetVariableSelection();
            UI.DisplayPlayerSelection(player1);
            UI.DisplayPlayerSelection(player2);
            setNumberOfWins(player1, player2);
            UI.DisplayNumberOfWins(player1, player2);
        }

        private bool GetIsGameOver()
        {
            if ( (player1.numberOfWins == numberOfWinsToWinGame || player2.numberOfWins == numberOfWinsToWinGame) )
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private string GetGameWinnerName()
        {
            if ( player1.numberOfWins == numberOfWinsToWinGame)
            {
                return player1.name;
            }
            else
            {
                return player2.name;
            }
        }

        private void PlayRounds()
        {
            Console.Clear();
            SetUpGame();
            while ( !isGameOver )
            {
                PlayRound();
                isGameOver = GetIsGameOver();
                if(!isGameOver)
                {
                    UI.GetAnyKeyToContinue();
                }
            }
            string gameWinnerName = GetGameWinnerName();
            UI.DisplayWinner(gameWinnerName);
            bool doPlayAgain = UI.getPlayAgainOption();
            if ( doPlayAgain )
            {
                StartGame();
            }
            else
            {
                return;
            }
        }
    }
}
