using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command
{
    public class SteakOrder : IOrder
    {
        private Chef chef;

        public SteakOrder(Chef chef)
        {
            this.chef = chef;
        }
        public void Execute()
        {
            chef.CookSteak();
        }
    }
}
