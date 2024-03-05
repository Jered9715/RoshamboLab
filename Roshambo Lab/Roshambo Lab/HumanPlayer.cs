using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roshambo_Lab
{
    internal class HumanPlayer : Player

    {
        public override string Name { get; set; }
        public override int PlayerChoice { get; set; }

        public void SetPlayerChoice(int userInput)
        {
        PlayerChoice = userInput;  
        }

        public override Roshambo GenerateRochambo()
        {
            if (PlayerChoice == 1)
            {
                return Roshambo.rock;
            }
            else if (PlayerChoice == 2)
            {
                return Roshambo.paper;
            }
            else
            {
                return Roshambo.scissors;
            }
        }
    
    }
}