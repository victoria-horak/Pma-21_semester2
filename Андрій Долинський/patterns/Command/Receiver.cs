﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command
{
    class Receiver
    {
        public void Action(string text)
        {
            Console.WriteLine("Отримав команду: " + text);
        }
    }
}
