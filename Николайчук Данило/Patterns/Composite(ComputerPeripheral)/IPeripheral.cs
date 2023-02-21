using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composite_goods_
{
    internal interface IPeripheral
    {
        string Name { get; set; }
        double Price { get; set; }
        void AddPeripheral(IPeripheral peripheral);
        void RemovePeripheral(IPeripheral peripheral);
        List<IPeripheral> GetPeripherals();
        double GetTotalPrice();
        string ToString();
        void Display();
    }
}
