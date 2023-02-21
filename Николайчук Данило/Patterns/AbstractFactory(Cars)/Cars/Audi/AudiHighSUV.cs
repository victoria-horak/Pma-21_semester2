using AbstractFactory_Cars_.CarsInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory_Cars_.Cars.Audi
{
    internal class AudiHighSUV : ISUV
    {
        public string GetName()
        {
            return "Audi q7";
        }
        public int GetPrice()
        {
            return 90000;
        }
        public void Drive()
        {
            Console.WriteLine("Driving an Audi q7");
        }
    }
}
