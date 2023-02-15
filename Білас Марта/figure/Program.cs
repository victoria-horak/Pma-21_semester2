using System;

namespace figura
{
    class Program
    {
        static void Main(string[] args)
        {
            Rectangle rectangle = new Rectangle(3,5);
            Console.WriteLine(rectangle);
            Square square = new Square(5);
            Console.WriteLine(square);
            Circle circle = new Circle(6);
            Console.WriteLine(circle);
        }
    }
}
