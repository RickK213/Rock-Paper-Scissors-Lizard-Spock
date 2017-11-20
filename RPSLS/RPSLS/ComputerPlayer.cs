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
        public Random randomNumber = new Random();

        //constructor
        public ComputerPlayer()
        {
            this.isHuman = false;
            this.name = "Computer";
        }

        //member methods
        public override void GetVariableSelection()
        {
            currentSelection = randomNumber.Next(5);
        }


    }
}
