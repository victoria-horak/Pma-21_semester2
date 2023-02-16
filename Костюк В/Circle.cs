using System;

namespace Figures
{
    class Circle : Figure
    {
        public Circle(double radius) : base(radius) { }

        public override double area() => Math.Round((Math.PI * side * side), 3);

        public override double perimetr() => Math.Round((2 * Math.PI * side), 3);

        public override void print() => Console.WriteLine("Circle: Length = " + perimetr() + "| Square = " + area());
    }
}