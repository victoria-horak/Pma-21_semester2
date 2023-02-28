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
            Client client = new Client();
            client.orderDrink(input);

        }
    }
}
