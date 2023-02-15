using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Figures
{
    class Circle: Figure
    {
        public Circle(double radius) : base(radius) { }

        public override double area()
        {
            return Math.Round((Math.PI * side * side), 3);
        }

        public override double perimetr()
        {
            return Math.Round((2 * Math.PI * side),3);
        }

        public override void print()
        {
            Console.WriteLine("Perimetr: " + perimetr() + " Square: " + area());
        }
    }
}
