using System;

namespace Shapes
{
    class Square : Rectangle
    {
        public Square(double side) : base(side, side) { }

        public override double Area()
        {
            return side * side;
        }

        public override double Perimetr()
        {
            return 4 * side;
        }

        public override void Print()
        {
            Console.WriteLine("Perimeter of figure:: " + Perimetr() + " Area of figure:: " + Area());
        }
    }
}