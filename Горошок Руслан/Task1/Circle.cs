using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskClass1
{
    class Circle : Shape
    {
        double PI = Math.PI;
        public Circle(double aSide) : base(aSide) { }

        public override double GetPerimetr()
        {
            return 2*PI*aSide;
        }
        public override double GetSquare()
        {
            return PI * Math.Pow(aSide,2);
        }
        public override void Display()
        {
            Console.WriteLine("It's a Circle : ");
            Console.WriteLine("Square = " + GetSquare());
            Console.WriteLine("Perimetr = " + GetPerimetr());
        }
    }
}
