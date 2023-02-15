using System;

namespace ConsoleApplication1
{
    class Reactangle : Shape
    {
        public double sideB;

        public Reactangle(double sideA, double sideB) : base(sideA)
        {
            this.sideB = sideB;
        }

        public override string Print()
        {
            return "Rectangle\n"+"perimeter=" + GetPerimeter() + "\n" + "area=" + GetArea();
        }

        public override double GetArea()
        {
            return sideB * Side;
        }

        public override double GetPerimeter()
        {
            return 2 * (sideB + Side);
        }
    }
}