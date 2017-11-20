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
            this.isHuman = true;
            this.name = "Player 1";
        }

        //member methods
        private void DisplayPlayerInterface()
        {
            Console.WriteLine(name + ": please make your selection:");
        }

        public override void GetVariableSelection()
        {
            DisplayPlayerInterface();
            UI.DisplayPlayerMenu();
            string userSelection = Console.ReadKey(true).KeyChar.ToString();
            currentSelection = int.Parse(userSelection);
            if (!(currentSelection >= 0 || currentSelection <= 4))
            {
                GetVariableSelection();
            }
        }

    }
}
