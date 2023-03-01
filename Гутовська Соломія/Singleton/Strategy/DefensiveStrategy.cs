using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strategy
{
    public class DefensiveStrategy : IStrategy
    {
        public void Attack()
        {
            Console.WriteLine("Defending and counter-attacking!");
        }
    }
}
