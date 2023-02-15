using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskClass1
{
    class Rectangle : Shape
    {
        public double bSide;
        public Rectangle(double aSide,double bSide) : base(aSide)
        {
            this.bSide = bSide;
        }

        public override double GetPerimetr()
        {
            return (2.0*(aSide + bSide));
        }
        public override double GetSquare()
        {
            return aSide * bSide;
        }
        public override void Display()
        {
            Console.WriteLine("It's a Rectangle : ");
            Console.WriteLine("Square = " + GetSquare());
            Console.WriteLine("Perimetr = " + GetPerimetr());
        }
    }
}
