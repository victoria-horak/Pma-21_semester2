
public class Program
{
    public static void Main()
    {
        string file = "employees.txt";
        IIterator<Employee> iterator = new Iterator.EmployeeFileIterator(file);
        Iterator.EmployeeProcessor processor = new Iterator.EmployeeProcessor(iterator);
        processor.Process();
    }
}
