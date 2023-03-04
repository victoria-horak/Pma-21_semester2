namespace DesignPattern_ChainOfResponsibility
{
    public class CFO : Handler
    {
        public override void Process(object request)
        {
            if ((request as Employee).expectedSalary <= 20000)
            {
                Console.WriteLine($"Employee {request} is hired by {GetType().Name}!");
            }
            else
            {
                Console.WriteLine($"Cannot be hired! Expectations are too big. Turned down by {GetType().Name}.");
            }
        }
    }
}
