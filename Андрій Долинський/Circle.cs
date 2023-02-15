using System;

namespace Shapes
{
    class Circle : Figure
    {
        public Circle(double radius) : base(radius) { }

        public override double Area()
        {
            return Math.Round((Math.PI * side * side), 5);
        }

        public override double Perimetr()
        {
            return Math.Round((2 * Math.PI * side), 5);
        }

        public override void Print()
        {
            Console.WriteLine("Perimeter of figure: " + Perimetr() + " Area of figure: " + Area());

        }
    }
}
