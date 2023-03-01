using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstract_Factory
{
    public class HyperXKeyBoard : KeyBoard
    {
        public override string getKeybordName()
        { 
            return "HyperX";
        }

        public override string getKeybordType()
        {
            return "Mechanical";
        }

        public override int getKeybordNumberOfClicks()
        {
            return 80000000;
        }

    }
}
