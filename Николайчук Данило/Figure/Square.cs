using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Figure
{
    internal class Square:Rectangle
    {
        public Square(double firstSide):base(firstSide, firstSide) { }
        public Square() : base() { }
        public override void display()
        {
            Console.WriteLine("Side: " + firstSide + "\nSquare: " + square() + "\nPerimetr: " + perimetr() + "\n");
        }
    }
}
