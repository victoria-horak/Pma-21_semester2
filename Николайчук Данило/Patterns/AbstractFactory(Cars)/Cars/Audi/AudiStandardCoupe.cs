using AbstractFactory_Cars_.CarsInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory_Cars_.Cars.Audi
{
    internal class AudiStandardCoupe:ICoupe
    {
        public string GetName()
        {
            return "Audi tt";
        }
        public int GetPrice()
        {
            return 55000;
        }
        public void Drive()
        {
            Console.WriteLine("Driving an Audi tt");
        }
    }
}
