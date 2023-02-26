using System;

namespace StatePattern
{
    class Program
    {
        static void Main(string[] args)
        {
            TV tv = new TV();
            tv.turnOn();
            tv.turnOn();
            tv.volumeUp();
            tv.volumeUp();
            tv.turnOff();
            tv.channelUp();
            tv.turnOff();
        }
    }
}
