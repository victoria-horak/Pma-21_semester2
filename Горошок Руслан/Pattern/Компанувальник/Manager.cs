using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composite
{
     class Manager : IEmployee
    {
        private List<IEmployee> subordinates = new List<IEmployee>();

        public string Name { get; set; }
        public double Salary { get; set; }

        public Manager(string name, double salary)
        {
            Name = name;
            Salary = salary;
        }

        public void add(IEmployee employee)
        {
            subordinates.Add(employee);
        }

        public void remove(IEmployee employee)
        {
            subordinates.Remove(employee);
        }

        public void display(int indent)
        {
            for (int i = 0; i < indent; i++)
            {
                Console.Write('-');
            }
            Console.WriteLine($" Manager: {Name} - {Salary}$");
            foreach (IEmployee employee in subordinates)
            {
                employee.display(indent + 2);
            }
        }

        public List<IEmployee> Subordinates
        {
            get { return subordinates; }
        }
    }
}