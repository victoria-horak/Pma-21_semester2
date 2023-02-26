using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatePattern
{
    public abstract class TVState
    {
        protected TV tv;

        public TVState() { tv = new TV(); }
        public TVState(TV tv)
        {
            this.tv = tv;
        }
        public void turnOn()
        {
            if (tv.IsOn == false)
            {
                tv.State = new TVOnState(tv);
                Console.WriteLine("Turning on the TV.");
            }
            else
                Console.WriteLine("TV is turned on.");
        }
        public void turnOff()
        {
            if (tv.IsOn)
            {
                tv.State = new TVOffState(tv);
                Console.WriteLine("Turning off the TV.");
            }
            else
                Console.WriteLine("TV is turned off.");
        }
        public abstract void volumeUp();
        public abstract void volumeDown();
        public abstract void channelUp();
        public abstract void channelDown();
    }

}
