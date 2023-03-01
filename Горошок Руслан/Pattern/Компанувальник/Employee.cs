using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composite
{
    public class Employee : IEmployee
    {
        public string Name { get; set; }
        public double Salary { get; set; }

        public Employee(string name, double salary)
        {
            Name = name;
            Salary = salary;
        }

        public void display(int indent)
        {
            for (int i = 0; i < indent; i++)
            {
                Console.Write('-');
            }
            Console.WriteLine($" {Name} - {Salary}$");
        }
    }
}
