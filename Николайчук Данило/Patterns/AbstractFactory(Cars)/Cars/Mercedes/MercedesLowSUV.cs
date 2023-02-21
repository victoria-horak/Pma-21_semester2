using AbstractFactory_Cars_.CarsInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory_Cars_.Cars.Mercedes
{
    internal class MercedesLowSUV : ISUV
    {
        public string GetName()
        {
            return "Mercedes glc-class";
        }
        public int GetPrice()
        {
            return 40000;
        }
        public void Drive()
        {
            Console.WriteLine("Driving a Mercedes glc-class");
        }
    }
}
