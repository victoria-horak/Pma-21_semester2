using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composite
{
     class SalaryCalculation
    {
        public double getTotalSalary(IEmployee employee)
        {
            double totalSalary = employee.Salary;
            if (employee is Manager manager)
            {
                foreach(IEmployee subordinate in manager.Subordinates)
                {
                    totalSalary += getTotalSalary(subordinate);
                }
            }
            return totalSalary;
        }
    }
}
