using System;

namespace Figures
{
    class Square : Rectangle
    {
        public Square(double side) : base(side, side) { }

        public override double area() => Math.Pow(side, 2);

        public override double perimetr() => 4 * side;

        public override void print() => Console.WriteLine("Square: Perimetr = " + perimetr() + "| Square = " + area());
    }
}