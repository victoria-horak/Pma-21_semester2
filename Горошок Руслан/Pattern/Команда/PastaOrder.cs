using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command
{
    public class PastaOrder : IOrder
    {
        private Chef chef;
        public PastaOrder(Chef chef)
        {
            this.chef = chef;
        }
        public void Execute()
        {
            chef.CookPasta();
        }
    }
}
