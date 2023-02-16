using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Figure
{
    abstract class Figura: IPerimeter, IArea
    {
        public abstract double GetPerimeter();
        public abstract double GetArea();
    }
}

