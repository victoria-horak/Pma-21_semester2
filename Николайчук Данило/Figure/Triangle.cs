using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Figure
{
    internal class Triangle : Figure
    {
        private int secondSide, thirdSide;
        public Triangle()
        {
            firstSide = secondSide = thirdSide = 0;
        }
        public Triangle(int firstSide, int secondSide, int thirdSide)
        {
            this.firstSide = firstSide; this.secondSide = secondSide; this.thirdSide = thirdSide;
        }
        public override double square()
        {
            double halfPerimetr = perimetr() / 2;
            return Math.Pow(halfPerimetr * (halfPerimetr - firstSide) * (halfPerimetr - secondSide) * (halfPerimetr - thirdSide), 0.5);
        }
        public override double perimetr()
        {
            return firstSide + secondSide + thirdSide;
        }
        public override void display()
        {
            Console.WriteLine("First side: " + firstSide + "\tSecond side: " + secondSide + "\tThird side: " + thirdSide + "\nSquare: " + square() + "\nPerimetr: " + perimetr() + "\n");
        }
    }
}
