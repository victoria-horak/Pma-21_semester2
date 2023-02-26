using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatePattern
{
    public class TVOffState : TVState
    {
        public TVOffState() : base() { }
        public TVOffState(TV tv) : base(tv)
        {
        }
        public override void channelUp()
        {
            Console.WriteLine("Can't change channels when the TV is off.");
        }

        public override void channelDown()
        {
            Console.WriteLine("Can't change channels when the TV is off.");
        }

        public override void volumeUp()
        {
            Console.WriteLine("Can't change volume when the TV is off.");
        }

        public override void volumeDown()
        {
            Console.WriteLine("Can't change volume when the TV is off.");
        }
    }
}
