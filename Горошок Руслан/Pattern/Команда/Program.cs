using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Chef chef = new Chef();

            SteakOrder steak = new SteakOrder(chef);
            SoupOrder soup = new SoupOrder(chef);
            PastaOrder pasta = new PastaOrder(chef);

            Waiter waiter = new Waiter();

            waiter.takeOrder(steak);
            waiter.takeOrder(soup);
            waiter.takeOrder(pasta);

            waiter.PlaceOrder();

        }
    }
}
