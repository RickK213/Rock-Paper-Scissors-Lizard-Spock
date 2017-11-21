using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPSLS
{
    public class HumanPlayer : Player
    {

        public HumanPlayer()
        {
            this.name = "Player 1";
        }

        private void DisplayPlayerInterface()
        {
            Console.WriteLine(name + ": please make your selection:");
        }

        public override void SetVariableSelection()
        {
            DisplayPlayerInterface();
            UI.DisplayPlayerMenu();
            string userSelection = Console.ReadKey(true).KeyChar.ToString();
            int userSelectionNumber;
            if( !int.TryParse(userSelection, out userSelectionNumber) || !(userSelectionNumber >= 0) || !(userSelectionNumber <= 4) )
            {
                Console.Clear();
                SetVariableSelection();
            }
            else
            {
                currentSelection = userSelectionNumber;
            }
        }

    }
}
