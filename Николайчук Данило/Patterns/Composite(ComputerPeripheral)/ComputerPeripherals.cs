using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composite_goods_
{
    internal class ComputerPeripherals : IPeripheral
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public ComputerPeripherals(string name, double price)
        {
            Name = name;
            Price = price;
        }
        public void AddPeripheral(IPeripheral peripheral)
        {
            Console.WriteLine("Cannot add peripheral to an element(leaf).");
        }
        public void RemovePeripheral(IPeripheral peripheral)
        {
            Console.WriteLine("Cannot remove peripheral from an element(Leaf).");
        }
        public List<IPeripheral> GetPeripherals()
        {
            return null;
        }
        public double GetTotalPrice()
        {
            return Price;
        }
        public override string ToString()
        {
            return Name + " price: " + Price + "\t";
        }
        public void Display()
        {
            Console.Write(Name + " price: " + Price);
        }
    }
}
