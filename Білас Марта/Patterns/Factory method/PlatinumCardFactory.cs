using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethodPattern
{
    public class PlatinumCardFactory: CardFactory
    {
        protected override ICreditCard makeProduct()
        {
            ICreditCard product = new PlatinumCard();
            return product;
        }
    }
}
