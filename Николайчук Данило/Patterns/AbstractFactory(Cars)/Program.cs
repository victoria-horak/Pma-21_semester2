using AbstractFactory_Cars_.CarFactoryInterface;
using AbstractFactory_Cars_.CarFactorys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory_Cars_
{
    class AbstractFactory_Cars
    {
        public static void Main()
        {
            ICarFactory audiFactory = new AudiFactory();
            Client audiClient = new Client(audiFactory, CarSegment.High);
            audiClient.Run();

            Console.WriteLine();
            ICarFactory mercedesFactory = new MercedesFactory();
            Client mercedesClient = new Client(mercedesFactory, CarSegment.Low);
            mercedesClient.Run();
        }
    }
}