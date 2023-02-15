using System;


namespace First_Project_on_Csharp
{
    class Circle : Shape
    {
        public Circle() => side1 = 0;
        public Circle(double side1) => this.side1 = side1;
        public override double Square() => 3.14 * side1 * side1;
        public override double Perimeter() => 2 * 3.14 * side1;
        public override void print()
        {
            Console.WriteLine("Circle: Radius = " + side1 + " || Square = " + Square() + " || Length = " + Perimeter());
        }

    }
}
