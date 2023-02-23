using System;

namespace Iterator
{
    public class EmployeeProcessor
    {
        private IIterator<Employee> iterator;

        public EmployeeProcessor(IIterator<Employee> iterator) => this.iterator = iterator;

        public void Process()
        {
            Console.WriteLine("Start processing");
            while (iterator.HasNext())
            {
                Employee employee = iterator.Next();
                Console.WriteLine($"Employee {employee.Id}: {employee.Name} salary {employee.Salary}");
            }
            Console.WriteLine("End processing");
        }
    }
}
