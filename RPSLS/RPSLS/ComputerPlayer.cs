using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPSLS
{
    public class ComputerPlayer : Player
    {

        public Random randomNumber = new Random();

        public ComputerPlayer()
        {
            this.name = "Computer";
        }

        public override void SetVariableSelection()
        {
            currentSelection = randomNumber.Next(5);
        }

    }
}
