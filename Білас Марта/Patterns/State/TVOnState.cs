using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatePattern
{
    public class TVOnState : TVState
    {
        public TVOnState() : base()
        {
        }
        public TVOnState(TV tv) : base(tv)
        {
        }

        public override void volumeUp()
        {
            if (tv.Volume < 100)
            {
                tv.Volume++;
                Console.WriteLine($"Volume up: {tv.Volume}");
            }
        }

        public override void volumeDown()
        {
            if (tv.Volume > 0)
            {
                tv.Volume--;
                Console.WriteLine($"Volume down: {tv.Volume}");
            }
        }

        public override void channelUp()
        {
            tv.CurrentChannel++;
            Console.WriteLine($"Channel up: {tv.CurrentChannel}");
        }

        public override void channelDown()
        {
            if (tv.CurrentChannel > 1)
            {
                tv.CurrentChannel--;
                Console.WriteLine($"Channel down: {tv.CurrentChannel}");
            }
        }
    }

}
