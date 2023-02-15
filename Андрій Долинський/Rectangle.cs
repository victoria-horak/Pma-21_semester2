using System;

namespace Shapes
{

        class Rectangle : Figure
        {
            private double secondSide;
            public Rectangle(double secondSide, double side) : base(side)
            {
                this.secondSide = secondSide;
            }

            public override double Area()
            {
                return side * secondSide;

            }

            public override double Perimetr()
            {
                return side * 2 + secondSide * 2;
            }

            public override void Print()
            {
                Console.WriteLine("Perimeter of figure:: " + Perimetr() + " Area of figure:: " + Area());

            }
        }
    
}
