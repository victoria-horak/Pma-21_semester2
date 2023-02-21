using AbstractFactory_Cars_.CarFactoryInterface;
using AbstractFactory_Cars_.CarsInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory_Cars_
{
    internal class Client
    {
        private ISedan sedan;
        private ISUV suv;
        private ICoupe coupe;
        public Client(ICarFactory factory, CarSegment segment)
        {
            sedan = factory.CreateSedan(segment);
            suv = factory.CreateSUV(segment);
            coupe = factory.CreateCoupe(segment);
        }
        public void Run()
        {
            Console.WriteLine("Creating vehicles using: " + sedan.GetName() + ", " + suv.GetName() + " and " + coupe.GetName());
            Console.WriteLine("Total cost: " + (sedan.GetPrice() + suv.GetPrice() + coupe.GetPrice()));
            sedan.Drive();
            suv.Drive();
            coupe.Drive();
        }
    }
}
