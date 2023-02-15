using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Figures
{
    internal class Square: Rectangle
    {
        public Square(double side): base(side, side) { }
        public override void Output()
        {
            Console.WriteLine("Square: First side is " + side + ", Perimeter is " + getPerimeter() + ", Area is " + getArea() + "\n");
        }
    }
}
