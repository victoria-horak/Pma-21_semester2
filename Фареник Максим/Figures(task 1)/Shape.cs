using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Figures
{
    internal abstract class Shape:IPerimeter,IArea
    {
        public double side;
        public abstract void Output();
        public abstract double getPerimeter();
        public abstract double getArea();
       


    }
}
