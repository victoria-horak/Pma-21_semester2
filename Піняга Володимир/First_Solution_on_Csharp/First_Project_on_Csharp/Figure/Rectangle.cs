using System;


namespace First_Project_on_Csharp
{
    class Rectangle : Shape
    {
        protected double side2;
        public Rectangle() => side1 = side2 = 0;
        public Rectangle(double side1, double side2)
        {
            this.side1 = side1;
            this.side2 = side2;
        }
            
        //public Rectangle(int n) => side2 = n;
        public override double Square() => side1 * side2;

        public override double Perimeter() => (side1 + side2) * 2;
        public override void print()
        {
            Console.WriteLine("Rectangle: Sides: " + side1 + ", "+side2+ " || Square = " + Square() + " || Perimeter = " + Perimeter());
        }



    }
}
