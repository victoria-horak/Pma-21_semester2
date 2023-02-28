using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory_Method
{
    internal class Client
    {
        IDrinkFactory factory;
        public void orderDrink(string input)
        {

            if (input == "coffee")
                factory = new CoffeeFactory();
            else if (input == "tea")
                factory = new TeaFactory();
            else if (input == "cocoa")
                factory = new CocoaFactory();
            else
                Console.WriteLine("Incorrect value");


            IDrink drink = factory.CreateDrink();
            drink.Prepare();
        }


    }
}
