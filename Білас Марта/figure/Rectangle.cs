using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace figura
{
    public class Rectangle : Shape
    {
        protected double secondSide;
        public Rectangle(double side, double secondSide)
        {
            this.side = side;
            this.secondSide = secondSide;
        }
        public double SecondSide
        { get { return this.secondSide; }
          set { this.secondSide = value; }  
        }
        public override double area()
        {
            return side * secondSide;
        }
        public override double perimetr()
        {
            return 2 * (side + secondSide);
        }
        public override string ToString()
        {
            return "first side: " + this.Side.ToString() + " second side: " + this.SecondSide.ToString() 
                + " perimeter: " + this.perimetr().ToString() + "area: " + this.area().ToString() + "\n";
        }

    }
}
