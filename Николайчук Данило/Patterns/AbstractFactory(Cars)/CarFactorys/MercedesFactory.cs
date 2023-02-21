using AbstractFactory_Cars_.CarFactoryInterface;
using AbstractFactory_Cars_.Cars.Mercedes;
using AbstractFactory_Cars_.CarsInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory_Cars_.CarFactorys
{
    internal class MercedesFactory: ICarFactory
    {
        public ISedan CreateSedan(CarSegment segment)
        {
            switch (segment)
            {
                case CarSegment.Low:
                    return new MercedesLowSedan();
                case CarSegment.Standard:
                    return new MercedesStandardSedan();
                case CarSegment.High:
                    return new MercedesHighSedan();
                default:
                    throw new ArgumentException($"Invalid car segment: {segment}");
            }
        }
        public ISUV CreateSUV(CarSegment segment)
        {
            switch (segment)
            {
                case CarSegment.Low:
                    return new MercedesLowSUV();
                case CarSegment.Standard:
                    return new MercedesStandardSUV();
                case CarSegment.High:
                    return new MercedesHighSUV();
                default:
                    throw new ArgumentException($"Invalid car segment: {segment}");
            }
        }
        public ICoupe CreateCoupe(CarSegment segment)
        {
            switch (segment)
            {
                case CarSegment.Low:
                    return new MercedesLowCoupe();
                case CarSegment.Standard:
                    return new MercedesStandardCoupe();
                case CarSegment.High:
                    return new MercedesHighCoupe();
                default:
                    throw new ArgumentException($"Invalid car segment: {segment}");
            }
        }
    }
}
