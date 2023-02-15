using Figure;
using System;

namespace figure
{
    public class figure
    {
        public static void Main()
        {
            Triangle triangle = new Triangle(4, 5, 6);
            Rectangle rectangle = new Rectangle(4, 7);
            Square square = new Square(6);
            Circle circle = new Circle(6);

            triangle.display();
            rectangle.display();
            square.display();
            circle.display();
        }
    }
}