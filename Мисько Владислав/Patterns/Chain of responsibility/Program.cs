namespace DesignPattern_ChainOfResponsibility
{
    public class Program
    {
        static void Main(string[] args)
        {
            Handler ceo = new CEO();
            Handler cto = new CTO();
            Handler cfo = new CFO();

            ceo.setSenior(cto);
            cto.setSenior(cfo);

            foreach (var employee in new[]
            {
                new Employee("Luke", "De Jong", 1000), new Employee("Karim", "Benzema", 14000), new Employee("Cristiano", "Ronaldo", 20000),  new Employee("Lionel", "Messi", 100000)
            })
            {
                ceo.Process(employee);
            }
        }
    }
}