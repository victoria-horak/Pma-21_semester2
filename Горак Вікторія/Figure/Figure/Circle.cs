using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Figure
{
    class Circle: Figura
    {
        private double radius;
        public Circle(double radius)
        {
            this.radius = radius;
        }
        public override double GetArea()
        {
            double area = Math.PI * radius * radius;
            return area;
        }
        public override double GetPerimeter()
        {
            double perimeter = 2 * Math.PI * radius;
            return perimeter;
         
        }
    }
    

}
