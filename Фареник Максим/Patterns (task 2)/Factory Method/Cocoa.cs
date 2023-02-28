using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory_Method
{
    internal class Cocoa : IDrink
    {
        public void Prepare()
        {
            Console.WriteLine("Preparing a cocoa...\n");
        }
    }
}
