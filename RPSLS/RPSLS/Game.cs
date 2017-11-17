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
        public bool isTwoPlayerMode = false;
        public int currentRound = 1;
        public int currentPlayer = 1;
        public Player player1;
        public Player player2;

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
            UI.DisplayGameModeOptions();
            int gameMode = UI.GetGameModeOption();
            SetGameMode(gameMode);
            PlayRounds();
        }

        private void SetUpGame()
        {
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

        private void PlayRound()
        {
            player1.GetVariableSelection();
            player2.GetVariableSelection();
            UI.DisplayRoundResults(player1);
            UI.DisplayRoundResults(player2);
            Console.ReadKey();
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
