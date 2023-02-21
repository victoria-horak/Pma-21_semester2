using System.IO;

namespace Iterator
{
    public class EmployeeFileIterator : IIterator<Employee>
    {
        private StreamReader file;
        private string currentLine;

        public EmployeeFileIterator(string filePath)
        {
            file = new StreamReader(filePath);
            currentLine = file.ReadLine();
        }

        public bool HasNext() => currentLine != null;

        public Employee Next()
        {
            Employee employee = new Employee();
            string[] fields = currentLine.Split(',');
            employee.Id = int.Parse(fields[0]);
            employee.Name = fields[1];
            employee.Salary = int.Parse(fields[2]);
            currentLine = file.ReadLine();
            return employee;
        }
    }
}
