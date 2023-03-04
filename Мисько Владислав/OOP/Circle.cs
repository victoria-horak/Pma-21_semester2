using System;

namespace testshit
{
    public class Circle : Shape
    {
        public Circle(double radius)
        {
            this.side = radius;
        }

        public override void DisplayFigure()
        {
            Console.WriteLine("Circle");
            Console.WriteLine($"P={getPerimeter()}");
            Console.WriteLine($"S={GetSquare()}");
        }

        public override double getPerimeter()
        {
            return 2 * Math.PI * side;
        }

        public override double GetSquare()
        {
            return Math.PI * side * side;
        }
    }
}
