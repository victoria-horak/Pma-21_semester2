using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstract_Factory
{
    public abstract class KeyBoard
    {
        public abstract string getKeybordName();
        public abstract string getKeybordType();
        public abstract int getKeybordNumberOfClicks();
    }
}
