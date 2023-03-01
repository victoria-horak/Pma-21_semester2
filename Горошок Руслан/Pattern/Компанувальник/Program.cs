using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composite
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Employee firstEmployee = new Employee("Ivan", 50000);
            Employee secondEmployee = new Employee("Dmutro", 60000);
            Employee thirdEmployee = new Employee("Katya", 65000);
            Manager firstManager = new Manager("Oksana", 70000);
            Manager secondManager= new Manager("Petro", 80000);

            firstManager.add(firstEmployee);
            secondManager.add(secondEmployee);
            secondManager.add(secondEmployee);

            Manager boss = new Manager("Boss", 90000);
            boss.add(firstManager); 
            boss.add(secondManager);

            SalaryCalculation calculation = new SalaryCalculation();
            Console.WriteLine("Company hierarchy:");
            boss.display(0);

            Console.WriteLine("\nGeneral salary: " + calculation.getTotalSalary(boss) + "$");
        }
    }
}
