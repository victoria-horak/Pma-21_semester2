using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace figura
{
    public abstract class Shape: IArea, IPerimeter
    {
        protected double side;
        public double Side
        {
            get { return this.side; }
            set { this.side = value; }
        }
        public abstract double area();
        public abstract double perimetr();
    }
}
