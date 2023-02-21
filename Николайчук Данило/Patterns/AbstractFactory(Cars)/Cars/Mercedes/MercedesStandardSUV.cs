using AbstractFactory_Cars_.CarsInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory_Cars_.Cars.Mercedes
{
    internal class MercedesStandardSUV : ISUV
    {
        public string GetName()
        {
            return "Mercedes gle-class";
        }
        public int GetPrice()
        {
            return 68000;
        }
        public void Drive()
        {
            Console.WriteLine("Driving a Mercedes gle-class");
        }
    }
}
