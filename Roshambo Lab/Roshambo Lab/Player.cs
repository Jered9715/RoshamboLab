using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roshambo_Lab
{
    internal abstract class Player
    {
        public abstract string Name { get; set; }
        public abstract int PlayerChoice { get; set; }



        public abstract Roshambo GenerateRochambo();
    }
}
