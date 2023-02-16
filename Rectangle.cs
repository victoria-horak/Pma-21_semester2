using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Figure
{
     class Rectangle : Figura
    {
        private double width;
        private double height;
        public Rectangle(double width, double height)
        {
            this.width = width;
            this.height = height;
        }
        public override double GetArea()
        {
            double area = width * height;
            return area;
        }
        public override double GetPerimeter()
        {
            double perimeter = 2 * width + 2 * height;
            return perimeter;
        }
    }
}
