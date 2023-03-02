using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreationalPatterns.Toys
{
    public class AnimalToy
    {
        protected string Name { get; set; }
        protected int Size { get; set; }

        public AnimalToy() { Name = "toy"; Size = 1; }
        public AnimalToy(string name, int size)
        {
            Name = name;
            Size = size;
        }

        public void PrintYourself()
        {
            Console.WriteLine($"I am {Name} and my size is {Size}.");
        }
    }
}
