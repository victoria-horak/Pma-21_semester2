using System;


namespace First_Project_on_Csharp 
{
    public class Program
    {
        public static void Main()
        {
            Rectangle rectangle = new Rectangle(2, 5);
            rectangle.print();

            Circle circle = new Circle(8);
            circle.print();

            Square square = new Square(6);
            square.print();

        }
    }
   
}


