using AbstractFactory_Cars_.CarsInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory_Cars_.Cars.Audi
{
    internal class AudiHighSedan:ISedan
    {
        public string GetName()
        {
            return "Audi a8";
        }
        public int GetPrice()
        {
            return 80000;
        }
        public void Drive()
        {
            Console.WriteLine("Driving an Audi a8");
        }
    }
}
