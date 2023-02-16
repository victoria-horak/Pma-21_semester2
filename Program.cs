using System;

namespace Figure
{
    class Program
    {
        static void Main(string[] args)
        {
           Console.WriteLine("Enter the radius of the circle:");
           double a =Convert.ToDouble(Console.ReadLine());
           Circle circle= new Circle(a);
           Console.WriteLine("The area of the circle:" + circle.GetArea());
           Console.WriteLine("The perimeter of the circle:" + circle.GetPerimeter());

           Console.WriteLine("Enter the first side of the rectangle:");
           double b = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Enter the second side of the rectangle:");
            double c = Convert.ToDouble(Console.ReadLine());
           Rectangle rectangle= new Rectangle(b,c);
           Console.WriteLine("The area of the rectangle :" + rectangle.GetArea());
           Console.WriteLine("The perimeter of the rectangle:" + rectangle.GetPerimeter());

            Console.WriteLine("Enter the side of the square:");
            double d = Convert.ToDouble(Console.ReadLine());
            Square square = new Square(d);
            Console.WriteLine("The area of the square:" + square.GetArea());
            Console.WriteLine("The perimeter of the square:" + square.GetPerimeter());






        }


    }
}
