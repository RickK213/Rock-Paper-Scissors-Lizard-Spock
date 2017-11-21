using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPSLS
{
    public class Game
    {
        private bool isGameOver;
        private bool isTwoPlayerMode;
        private Player player1;
        private Player player2;
        private int numberOfWinsToWinGame = 2;

        private void DoGameOver()
        {
            string gameWinnerName = GetGameWinnerName();
            UI.DisplayWinner(gameWinnerName);
            bool doPlayAgain = UI.getPlayAgainOption();
            if (doPlayAgain)
            {
                StartGame();
            }
            else
            {
                return;
            }
        }

        private string GetGameWinnerName()
        {
            if (player1.numberOfWins == numberOfWinsToWinGame)
            {
                return player1.name;
            }
            else
            {
                return player2.name;
            }
        }

        private bool GetIsGameOver()
        {
            if ((player1.numberOfWins == numberOfWinsToWinGame || player2.numberOfWins == numberOfWinsToWinGame))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void PlayRounds()
        {
            Console.Clear();
            SetUpGame();
            while (!isGameOver)
            {
                PlaySingleRound();
                isGameOver = GetIsGameOver();
                if (!isGameOver)
                {
                    UI.GetAnyKeyToContinue();
                }
            }
            DoGameOver();
        }

        private void PlaySingleRound()
        {
            player1.SetVariableSelection();
            player2.SetVariableSelection();
            player1.DisplayVariableSelection();
            player2.DisplayVariableSelection();
            SetNumberOfWins(player1, player2);
            UI.DisplayNumberOfWins(player1, player2);
        }

        private void SetGameMode(int gameMode)
        {
            if (gameMode == 2)
            {
                isTwoPlayerMode = true;
            }
            else
            {
                isTwoPlayerMode = false;
            }
        }

        private void SetNumberOfWins(Player player1, Player player2)
        {
            int numberOfVariables = UI.gameVariables.Count();
            int roundWinDeterminer = (numberOfVariables + player1.currentSelection - player2.currentSelection) % numberOfVariables;
            if (roundWinDeterminer == 0)
            {
                UI.DisplayRoundOutcome(player1, player2, true);
            }
            else if (roundWinDeterminer % 2 == 1)
            {
                UI.DisplayRoundOutcome(player1, player2, false);
                player1.numberOfWins++;
            }
            else
            {
                UI.DisplayRoundOutcome(player2, player1, false);
                player2.numberOfWins++;
            }
        }

        private void SetUpGame()
        {
            isGameOver = false;

            player1 = new HumanPlayer();

            if ( isTwoPlayerMode )
            {
                player2 = new HumanPlayer();
                player2.name = "Player 2";
            }
            else
            {
                player2 = new ComputerPlayer();
            }
        }

        public void StartGame()
        {
            UI.DisplayInstructions();
            int gameMode = UI.GetGameModeOption();
            SetGameMode(gameMode);
            PlayRounds();
        }

    }
}