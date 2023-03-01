using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command
{
    public class Waiter
    {
        private List<IOrder> orders = new List<IOrder>();
        public void takeOrder(IOrder order)
        {
            orders.Add(order);
        }

        public void PlaceOrder()
        {
            foreach(IOrder order in orders)
            {
                order.Execute();
            }
            orders.Clear();
        }

    }
}
