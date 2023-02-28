using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Singleton
{
 
    class Program
    {
        static void Main(string[] args)
        {
            Player player1 = Player.Instance;
            player1.Name = "Ihor";
            player1.Age = 20;
            player1.Game = "Monopoly";
            player1.Score = 100;

            Player player2 = Player.Instance;
            Console.WriteLine(player2.Name);
            Console.WriteLine(player2.Age);
            Console.WriteLine(player2.Game);
            Console.WriteLine(player2.Score);  
        }
    }
}
