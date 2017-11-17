using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPSLS
{
    public class ComputerPlayer : Player
    {

        //member variables

        //constructor
        public ComputerPlayer()
        {
            this.isHuman = false;
            this.name = "Computer";
        }

        //member methods
        public override void GetVariableSelection()
        {
            currentSelection = UI.randomNumber.Next(5);
        }


    }
}
