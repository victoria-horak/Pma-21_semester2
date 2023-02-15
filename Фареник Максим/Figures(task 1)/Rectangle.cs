using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Figures
{
    internal class Rectangle : Shape
    {
        public double secondSide;
        public Rectangle()
        {
            side = 0;
            secondSide = 0;
        }
        public Rectangle(double side, double secondSide)
        {
            this.side = side;
            this.secondSide = secondSide;
        }
        public override double getPerimeter()
        {
            double perimeter = (secondSide + side) * 2;
            return perimeter;
        }
        public override double getArea()
        {
            double area = secondSide * side;
            return area;
        }
        public override void Output()
        {
            Console.WriteLine("Rectangle: First side is " + side + ", Second side is " + secondSide + ", Perimeter is " + getPerimeter() + ", Area is " + getArea() + "\n");
        }

    }
}
