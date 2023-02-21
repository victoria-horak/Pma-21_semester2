using AbstractFactory_Cars_.CarsInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace AbstractFactory_Cars_.CarFactoryInterface
{
    public enum CarSegment
    {
        Low,
        Standard,
        High
    }
    internal interface ICarFactory
    {
        ISedan CreateSedan(CarSegment segment);
        ISUV CreateSUV(CarSegment segment);
        ICoupe CreateCoupe(CarSegment segment);
    }
}
