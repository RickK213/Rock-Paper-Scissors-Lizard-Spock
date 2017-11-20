using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPSLS
{
    public abstract class Player
    {

        //member variables
        public int numberOfWins;
        public string name;
        public int currentSelection;

        //constructor
        public Player()
        {

        }

        //member methods
        public abstract void SetVariableSelection();

        public void DisplayVariableSelection()
        {
            Console.WriteLine("{0} selected {1}", name, UI.gameVariables[currentSelection]);
        }
    }
}
