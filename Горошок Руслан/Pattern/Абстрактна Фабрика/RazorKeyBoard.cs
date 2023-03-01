using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstract_Factory
{
    public class RazorKeyBoard :KeyBoard
    {
        public override string getKeybordName()
        {
            return "Razor";
        }

        public override string getKeybordType()
        {
            return "Membrane";
        }

        public override int getKeybordNumberOfClicks()
        {
            return 700000000;
        }
    }
}
