using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory_Method
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("What do you want to drink coffee, tea or cocoa?");
            string input = Console.ReadLine();
            IDrinkFactory factory;
            switch (input)
            {
                case "coffee":
                    factory = new CoffeeFactory();
                    break;
                case "tea":
                    factory = new TeaFactory();
                    break;
                case "cocoa":
                    factory = new CocoaFactory();
                    break;
                default:
                    Console.WriteLine("Incorrect input");
                    return;
            }
            IDrink drink = factory.CreateDrink();
            drink.Prepare();
        }
    }
}
