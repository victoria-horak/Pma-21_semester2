using System;

namespace ConsoleApplication1
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Shape rectangle = new Reactangle(2, 3);
            Console.WriteLine(rectangle.Print());
            Console.WriteLine("\n");
            Shape circle = new Circle(2);
            Console.WriteLine(circle.Print());
            Console.WriteLine("\n");
            Shape square = new Square(3);
            Console.WriteLine(square.Print());
        }
    }
}