using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory_Cars_.CarsInterface
{
    internal interface ICoupe
    {
        string GetName();
        int GetPrice();
        void Drive();
    }
}
