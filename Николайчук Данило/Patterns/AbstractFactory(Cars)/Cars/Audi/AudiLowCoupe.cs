using AbstractFactory_Cars_.CarsInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory_Cars_.Cars.Audi
{
    internal class AudiLowCoupe : ICoupe
    {
        public string GetName()
        {
            return "Audi a5 coupe";
        }
        public int GetPrice()
        {
            return 30000;
        }
        public void Drive()
        {
            Console.WriteLine("Driving an Audi a5");
        }
    }
}
