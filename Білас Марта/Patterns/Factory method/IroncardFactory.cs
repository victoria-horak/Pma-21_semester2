using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethodPattern
{
    public class IroncardFactory: CardFactory
    {
        protected override ICreditCard makeProduct()
        {
            return new IronCard();
        }
    }
}
