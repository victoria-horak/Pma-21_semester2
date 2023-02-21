using AbstractFactory_Cars_.CarFactoryInterface;
using AbstractFactory_Cars_.Cars.Audi;
using AbstractFactory_Cars_.CarsInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory_Cars_.CarFactorys
{
    internal class AudiFactory : ICarFactory
    {
        public ISedan CreateSedan(CarSegment segment)
        {
            switch (segment)
            {
                case CarSegment.Low:
                    return new AudiLowSedan();
                case CarSegment.Standard:
                    return new AudiStandardSedan();
                case CarSegment.High:
                    return new AudiHighSedan();
                default:
                    throw new ArgumentException($"Invalid car segment: {segment}");
            }
        }
        public ISUV CreateSUV(CarSegment segment)
        {
            switch (segment)
            {
                case CarSegment.Low:
                    return new AudiLowSUV();
                case CarSegment.Standard:
                    return new AudiStandardSUV();
                case CarSegment.High:
                    return new AudiHighSUV();
                default:
                    throw new ArgumentException($"Invalid car segment: {segment}");
            }
        }
        public ICoupe CreateCoupe(CarSegment segment)
        {
            switch (segment)
            {
                case CarSegment.Low:
                    return new AudiLowCoupe();
                case CarSegment.Standard:
                    return new AudiStandardCoupe();
                case CarSegment.High:
                    return new AudiHighCoupe();
                default:
                    throw new ArgumentException($"Invalid car segment: {segment}");
            }
        }
    }
}
