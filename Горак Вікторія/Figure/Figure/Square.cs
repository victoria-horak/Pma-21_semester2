using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Figure
{
    class Square: Rectangle
    {
      
        private double side_a;
       
        public Square(double side_a) : base(side_a, side_a)
        { 
            this.side_a = side_a; 
        }

        public override double GetArea()
        {
            double area = side_a * side_a;
            return area;

        }
        public override double GetPerimeter()
        {
            double perimeter = side_a * 4;
            return perimeter;
        }

    }
}
