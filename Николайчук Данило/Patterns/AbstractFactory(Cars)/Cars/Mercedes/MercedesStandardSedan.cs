using AbstractFactory_Cars_.CarsInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory_Cars_.Cars.Mercedes
{
    internal class MercedesStandardSedan : ISedan
    {
        public string GetName()
        {
            return "Mercedes e-class";
        }
        public int GetPrice()
        {
            return 50000;
        }
        public void Drive()
        {
            Console.WriteLine("Driving a Mercedes e-class");
        }
    }
}
