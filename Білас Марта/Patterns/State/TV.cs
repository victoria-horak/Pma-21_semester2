using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatePattern
{
    public class TV
    {
        private TVState state;
        public bool IsOn { get; set; }
        public TVState State { get => state; set => state = value; }
        public int CurrentChannel { get; set; }
        public int Volume { get; set; }

        public TV()
        {
            this.State = new TVOffState(this);
            this.Volume = 25;
            this.CurrentChannel = 1;
            this.IsOn = false;
        }

        public void turnOn()
        {
            state.turnOn();
            this.IsOn = true;
        }

        public void turnOff()
        {
            state.turnOff();
            this.IsOn = false;
        }

        public void channelUp()
        {
            state.channelUp();
        }

        public void channelDown()
        {
            state.channelDown();
        }

        public void volumeUp()
        {
            state.volumeUp();
        }

        public void volumeDown()
        {
            state.volumeDown();
        }
    }


}

