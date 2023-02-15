using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Figure
{
    internal abstract class Figure:IPerimetr,ISquare
    {
        public double firstSide;
        public abstract void display();
        public abstract double square();
        public abstract double perimetr();
    }
}
