using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Composite_goods_
{
    internal class BoxWithComputerPeripherals : IPeripheral
    {
        private List<IPeripheral> peripherals = new List<IPeripheral>();
        public string Name { get; set; }
        public double Price { get; set; }
        public BoxWithComputerPeripherals(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Component name cannot be null or empty.");
            }
            Name = name;
        }
        public void AddPeripheral(IPeripheral peripheral)
        {
            if (peripheral == null)
            {
                throw new ArgumentNullException("Cannot add null peripheral.");
            }
            peripherals.Add(peripheral);
            Price += peripheral.Price;
        }
        public void RemovePeripheral(IPeripheral peripheral)
        {
            if (peripheral == null)
            {
                throw new ArgumentNullException("Cannot remove null peripheral.");
            }
            peripherals.Remove(peripheral);
            Price -= peripheral.Price;
        }
        public List<IPeripheral> GetPeripherals()
        {
            return peripherals;
        }
        public double GetTotalPrice()
        {
            double total = 0;
            foreach (IPeripheral peripheral in peripherals)
            {
                total += peripheral.GetTotalPrice();
            }
            return total;
        }
        public override string ToString()
        {
            string text = "";
            text += Name + " peripheral:\n";
            foreach (IPeripheral peripheral in peripherals)
            {
                text += peripheral + "\n";
            }
            return text;
        }
        public void Display()
        {
            Console.WriteLine(Name + " peripheral: ");
            foreach (IPeripheral peripheral in peripherals)
            {
                Console.WriteLine(peripheral + "\n");
            }
        }
    }
}
