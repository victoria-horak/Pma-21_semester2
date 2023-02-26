using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethodPattern
{
    class PlatinumCard : ICreditCard
    {
        public string cardType()
        {
            return "Platinum";
        }
        public int creditLimit()
        {
            return 55654;
        }
        public int annualCharge()
        {
            return 3546;
        }
        public void show()
        {
            Console.WriteLine("Card type: {0}", cardType());
            Console.WriteLine("Credit limit: {0}", creditLimit());
            Console.WriteLine("Annual charge: {0}", annualCharge());
        }
    }
}
