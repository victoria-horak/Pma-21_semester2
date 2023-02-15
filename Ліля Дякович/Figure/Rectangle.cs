using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Figures
{
    class Rectangle: Figure
    {
        private double secondSide;
        public Rectangle(double secondSide, double side):base(side)
        {
            this.secondSide = secondSide;
        }

        public override double area()
        {
            return side * secondSide;

        }

        public override double perimetr()
        {
            return side * 2 + secondSide * 2;
        }

        public override void print()
        {
            Console.WriteLine("Perimetr: " + perimetr() + " Square: " + area());
        }
    }
}
