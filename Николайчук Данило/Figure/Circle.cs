using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Figure
{
    internal class Circle : Figure
    {
        public Circle()
        {
            firstSide = 0;
        }
        public Circle(double firstSide)
        {
            this.firstSide = firstSide;
        }
        public override double perimetr()
        {
            return 2 * 3.14 * firstSide;
        }
        public override double square()
        {
            return Math.Pow(3.14 * firstSide, 2);
        }
        public override void display()
        {
            Console.WriteLine("Radius: " + firstSide + "\nSquare: " + square() + "\nPerimetr: " + perimetr() + "\n");
        }
    }
}
