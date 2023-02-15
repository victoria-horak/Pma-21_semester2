using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace figura
{
    public class Circle : Shape
    {
        public Circle(double side)
        {
            this.side = side;
        }
        public override double area()
        {
            return 2 * side * Math.PI;
        }
        public override double perimetr()
        {
            return side * side * Math.PI;
        }
        public override string ToString()
        {
            return "side: " + this.Side.ToString() + " perimeter: " + String.Format("{0:0.00}", this.perimetr())
                + " area: " + String.Format("{0:0.000}", this.area()) + "\n";
        }
    }
}
