using System;

namespace Figures
{
    class Rectangle : Figure
    {
        private double secondSide;
        public Rectangle(double secondSide, double side) : base(side) => this.secondSide = secondSide;

        public override double area() => side * secondSide;

        public override double perimetr() => (side + secondSide) * 2;

        public override void print() => Console.WriteLine("Rectangle: Perimetr = " + perimetr() + "| Square = " + area());
    }
}