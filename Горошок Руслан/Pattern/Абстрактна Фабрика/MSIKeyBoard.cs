using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstract_Factory
{
    public class MSIKeyBoard : KeyBoard
    {
        public override string getKeybordName()
        {
            return "MSI";
        }

        public override string getKeybordType()
        {
            return "semi-mechanical/membrane";
        }

        public override int getKeybordNumberOfClicks()
        {
            return 40000000;
        }
    }
}
