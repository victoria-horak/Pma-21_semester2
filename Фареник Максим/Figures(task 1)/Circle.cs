using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Figures
{
    internal class Circle:Shape
    {
        public Circle()
        {
            side = 0;
        }
        public Circle(double side)
        {
            this.side = side;
        }
        public override double getPerimeter()
        {
            double perimeter = 2.0 * 3.14 * side;
            return perimeter;
        }
        public override double getArea()
        {
            double area = 3.14 * side * side;
            return area;
        }
        public override void Output()
        {
            Console.WriteLine("Circle: Radius is " + side + ", Perimeter is " + getPerimeter() + ", Area is " + getArea() + "\n");
        }

    }
}
