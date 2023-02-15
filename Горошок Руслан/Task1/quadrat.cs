using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskClass1
{
    internal class quadrat : Rectangle
    {
        public quadrat(double bSide) : base(bSide,bSide) { }

        public override double GetPerimetr()
        {
            return 4*bSide;
        }
        public override double GetSquare()
        {
            return bSide * bSide;
        }
        public override void Display()
        {
            Console.WriteLine("It's a Quadrat : ");
            Console.WriteLine("Square = " + GetSquare());
            Console.WriteLine("Perimetr = " + GetPerimetr());
        }
    }
}
