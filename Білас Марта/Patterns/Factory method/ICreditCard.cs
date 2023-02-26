using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethodPattern
{

    public interface ICreditCard
    {
        string cardType();
        int creditLimit();
        int annualCharge();
        public void show();
    }

}
