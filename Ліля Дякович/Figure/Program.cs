using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Figures
{
    class Program
    {
        static void Main(string[] args)
        {
            Rectangle rec = new Rectangle(2, 4);
            rec.print();
            Console.WriteLine();
            Circle cir = new Circle(3);
            cir.print();
            Console.WriteLine();
            Square square = new Square(5);
            square.print();

        }
    }
}
