using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roshambo_Lab
{
    internal class RandomPlayer : Player
    {
        public override string Name { get; set; }
        public override int PlayerChoice { get; set ; }

        public override Roshambo GenerateRochambo()
        {
            Random rnd = new Random();
            int randomInteger = rnd.Next(1,4);

            if (randomInteger == 1)
            {
                return Roshambo.rock;
            }
            else if (randomInteger == 2)
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
