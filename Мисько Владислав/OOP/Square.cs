using System;

namespace testshit
{
    public class Square : Rectangle
    {
        public Square(double side) : base(side, side)
        {
        }

        public override void DisplayFigure()
        {
            Console.WriteLine("Square");
            Console.WriteLine($"P={getPerimeter()}");
            Console.WriteLine($"S={GetSquare()}");
        }

        public override double getPerimeter()
        {
            Console.WriteLine("it's square");
            return base.getPerimeter();
        }

    }
}
