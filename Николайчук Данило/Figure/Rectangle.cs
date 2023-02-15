using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Figure
{
    internal class Rectangle : Figure
    {
        protected double secondSide;
        public Rectangle() { firstSide = secondSide = 0; }
        public Rectangle(double firstSide, double secondSide)
        {
            this.firstSide = firstSide;
            this.secondSide = secondSide;
        }
        public override double square()
        {
            return firstSide * secondSide;
        }
        public override double perimetr()
        {
            return 2 * (firstSide + secondSide);
        }
        public override void display()
        {
            Console.WriteLine("First side: " + firstSide + "\tSecond side: " + secondSide + "\nSquare: " + square() + "\nPerimetr: " + perimetr() + "\n");
        }
    }
}
