using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adapter
{
    class Charger : ICharger
    {
        public void Charge()
        {
            Console.WriteLine("Charging using the standart version!");
        }
    }
}
