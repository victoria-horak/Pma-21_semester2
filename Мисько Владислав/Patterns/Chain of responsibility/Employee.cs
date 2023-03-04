namespace DesignPattern_ChainOfResponsibility
{
    public class Employee
    {
        public string name { get; set; }
        public string surname { get; set; }
        public int expectedSalary { get; set; }

        public Employee(string name, string surname, int expectedSalary)
        {
            this.name = name;
            this.surname = surname;
            this.expectedSalary = expectedSalary;
        }

        public override string ToString()
        {
            return $"Name: {name}. Surname: {surname}. Expected salary: {expectedSalary}";
        }

    }
}
