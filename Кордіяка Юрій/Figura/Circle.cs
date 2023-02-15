using System;
using System.Text.RegularExpressions;

namespace ConsoleApplication1
{
    class Circle : Shape
    {
        public Circle(double radius) : base(radius){}

        public override string Print()
        {
            return "Circle\n"+"perimeter=" + GetPerimeter() + "\n" + "area=" + GetArea();
        }

        public override double GetPerimeter()
        {
            return 2 * Math.PI * Side;
        }

        public override double GetArea()
        {
            return 2 * Side * Side;
        }
    }
}