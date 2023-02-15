using System;

namespace Shapes
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Rectangle:");
            Rectangle rectangle = new Rectangle(5, 6);
            rectangle.Print();
            Console.WriteLine("\n");

            Console.WriteLine("Circle : ");
            Circle circle = new Circle(4);
            circle.Print();
            Console.WriteLine("\n");

            Console.WriteLine("Square : ");
            Square square = new Square(6);
            square.Print();
            Console.WriteLine("\n");

        }
    }
}
