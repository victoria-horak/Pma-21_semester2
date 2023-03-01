using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command
{
    public class SoupOrder :IOrder
    {
        private Chef chef;
        public SoupOrder(Chef chef)
        {
            this.chef = chef;
        } 
        
        public void Execute()
        {
            chef.CookSoup();
        }

    }
}
