using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstract_Factory
{
    public class MSIKeyBoardFactory : KeyboradFactory
    {
        public override KeyBoard createKeyBoard()
        {
            return new MSIKeyBoard();
        }
    }
}
