using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Figures
{
    class Square : Rectangle
    {
        public Square(double side) : base(side, side) { }

        public override double area()
        {
            return side * side;
        }

        public override double perimetr()
        {
            return 4 * side;
        }

        public override void print()
        {
            Console.WriteLine("Perimetr: " + perimetr() + " Square: " + area());
        }
    }
}
