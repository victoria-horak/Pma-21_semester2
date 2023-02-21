using AbstractFactory_Cars_.CarsInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory_Cars_.Cars.Audi
{
    internal class AudiLowSedan:ISedan
    {
        public string GetName()
        {
            return "Audi a3";
        }
        public int GetPrice()
        {
            return 20000;
        }
        public void Drive()
        {
            Console.WriteLine("Driving an Audi a3");
        }
    }
}
