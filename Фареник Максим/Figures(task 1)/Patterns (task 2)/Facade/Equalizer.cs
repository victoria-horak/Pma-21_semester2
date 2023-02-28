using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facade
{
    public class Equalizer
    {
        public void EQProcess()
        {
            Console.WriteLine("Equalizing is in process...\n");
        }
        public void EQFinished()
        {
            Console.WriteLine("Equalizing is successfully finished\n");
        }
    }
}
