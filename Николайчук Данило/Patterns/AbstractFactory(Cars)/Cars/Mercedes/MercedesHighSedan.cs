using AbstractFactory_Cars_.CarsInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory_Cars_.Cars.Mercedes
{
    internal class MercedesHighSedan : ISedan
    {
        public string GetName()
        {
            return "Mercedes s-class";
        }
        public int GetPrice()
        {
            return 100000;
        }
        public void Drive()
        {
            Console.WriteLine("Driving a Mercedes s-class");
        }
    }
}
