using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace figura
{
    public class Square : Rectangle
    {
        public Square(double side) : base(side, side) { }
        public override string ToString()
        {
            return "side: " + this.Side.ToString() + " perimeter: " + this.perimetr().ToString() 
                + " area: " + this.area().ToString() + "\n";
        }
    }
}
