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

        public override int GenerateRochambo(int userInput)
        {
            return userInput;
        }
    }
}
