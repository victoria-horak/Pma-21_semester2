using System;

namespace Figures
{
    class Program
    {
        static void Main(string[] args)
        {
            double rec_side, rec_sec_side, radius, square_side;

            Console.WriteLine("Input rectangle first side: ");
            rec_side = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Input rectangle second side: ");
            rec_sec_side = Convert.ToDouble(Console.ReadLine());
            Figure rectangle = new Rectangle(rec_side, rec_sec_side);
            rectangle.print();
            Console.WriteLine();

            Console.WriteLine("Input radius: ");
            radius = Convert.ToDouble(Console.ReadLine());
            Figure circle = new Circle(radius);
            circle.print();
            Console.WriteLine();

            Console.WriteLine("Input square side: ");
            square_side = Convert.ToDouble(Console.ReadLine());
            Figure square = new Square(square_side);
            square.print();
            Console.WriteLine();
        }
    }
}