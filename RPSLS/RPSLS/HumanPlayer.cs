using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPSLS
{
    public class HumanPlayer : Player
    {

        //member variables


        //constructor
        public HumanPlayer()
        {
            this.name = "Player 1";
        }

        //member methods
        private void DisplayPlayerInterface()
        {
            Console.WriteLine(name + ": please make your selection:");
        }

        public override void SetVariableSelection()
        {
            DisplayPlayerInterface();
            UI.DisplayPlayerMenu();
            string userSelection = Console.ReadKey(true).KeyChar.ToString();
            int number;
            if( !int.TryParse(userSelection, out number) || !(int.Parse(userSelection) >= 0) || !(int.Parse(userSelection) <= 4) )
            {
                Console.Clear();
                SetVariableSelection();
            }
            else
            {
                currentSelection = int.Parse(userSelection);
            }
        }

    }
}
