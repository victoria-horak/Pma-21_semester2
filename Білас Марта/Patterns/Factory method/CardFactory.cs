using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethodPattern
{
     abstract public class CardFactory
    {
        protected abstract ICreditCard makeProduct();
        public ICreditCard CreateProduct()
        {
            return this.makeProduct();
        }
    }
}
