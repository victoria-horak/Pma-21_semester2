using System;


namespace First_Project_on_Csharp
{
    class Square: Rectangle
    {
        public Square(double side1) : base(side1, side1) { }
        public Square(): base() { }
        public override void print()
        {
            Console.WriteLine("Square: Side = " + side1 + " || Square = " + Square() + " || Perimeter = " + Perimeter());
        }
            
    }
}
