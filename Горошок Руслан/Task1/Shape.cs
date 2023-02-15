using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace TaskClass1
{
    public abstract class Shape : ISquare, IPerimetr
    {
        public double aSide;

        public Shape(double aSide)
        {
            this.aSide = aSide;
        }
        public abstract double GetSquare();
        public abstract double GetPerimetr();
        public abstract void Display();
    }
}
