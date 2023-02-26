using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethodPattern
{
    public class IronCard : ICreditCard
    {
        public string cardType()
        {
            return "Iron";
        }
        public int creditLimit()
        {
            return 7654;
        }
        public int annualCharge()
        {
            return 6754;

        }
        public void show()
        {
            Console.WriteLine("Card type: {0}", cardType());
            Console.WriteLine("Credit limit: {0}", creditLimit());
            Console.WriteLine("Annual charge: {0}", annualCharge());
        }
    }
}
