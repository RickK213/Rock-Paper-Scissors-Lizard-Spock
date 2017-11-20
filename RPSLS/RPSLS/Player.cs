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
        public int numberOfWins = 0;
        public string name;
        public int currentSelection;
        public bool isHuman;

        //constructor
        public Player()
        {

        }

        //member methods
        public abstract void SetVariableSelection();

    }
}
