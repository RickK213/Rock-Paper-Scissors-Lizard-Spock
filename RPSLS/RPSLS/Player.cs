using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPSLS
{
    public abstract class Player
    {

        public int numberOfWins;
        public string name;
        public int currentSelection;

        public void DisplayVariableSelection()
        {
            Console.WriteLine("{0} selected {1}", name, UI.gameVariables[currentSelection]);
        }

        public abstract void SetVariableSelection();

    }
}