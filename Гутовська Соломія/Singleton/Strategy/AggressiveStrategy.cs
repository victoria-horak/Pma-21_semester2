using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strategy
{
    public class AggressiveStrategy : IStrategy
    {
        public void Attack()
        {
            Console.WriteLine("Attacking aggressively!");
        }
    }
}
