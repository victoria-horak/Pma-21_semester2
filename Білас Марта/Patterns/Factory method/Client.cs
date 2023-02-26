using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethodPattern
{
    public class Client
    {
        public CardFactory cardFactory;
        public void initialize(string cardType)
        {
            if (cardType == "Platinum")
                cardFactory = new PlatinumCardFactory();
            else if (cardType == "Iron")
                cardFactory = new IroncardFactory();
            else
                Console.WriteLine("thre is no such card");
        }

        public void show()
        {

        }
    }
}
