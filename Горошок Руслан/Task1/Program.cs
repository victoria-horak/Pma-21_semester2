using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskClass1
{
    internal class Program
    {
        static void Main()
        {
            Circle circle = new Circle(10);
            circle.Display();
            Rectangle rectangle = new Rectangle(3,4);
            rectangle.Display();
            quadrat quadrat = new quadrat(2);
            quadrat.Display();
        }
    }
}
