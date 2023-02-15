using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Figures
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Shape circle = new Circle(3);
            circle.Output();
            Shape rectangle = new Rectangle(2, 4);
            rectangle.Output();
            Shape square = new Square(3);
            square.Output();

        }
    }
}
