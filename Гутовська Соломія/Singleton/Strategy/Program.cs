using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strategy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var player = new Player();
            player.SetStrategy(new AggressiveStrategy());
            player.Attack(); 

            player.SetStrategy(new DefensiveStrategy()); 
            player.Attack();
        }
    }
}
