using System;

namespace testshit
{
    public class Rectangle : Shape, IPerimeter, ISquare
    {
        private double secondSide;

        public Rectangle(double firstSide, double secondSide)
        {
            this.side = firstSide;
            this.secondSide = secondSide;
        }

        public override void DisplayFigure()
        {
            Console.WriteLine("Rectangle");
            Console.WriteLine($"P={getPerimeter()}");
            Console.WriteLine($"S={GetSquare()}");
        }

        public override double getPerimeter()
        {
            return 2 * (side + secondSide);
        }

        public override double GetSquare()
        {
            return side * secondSide;
        }
    }
}
