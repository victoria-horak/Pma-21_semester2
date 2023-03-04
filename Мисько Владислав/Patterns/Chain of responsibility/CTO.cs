namespace DesignPattern_ChainOfResponsibility
{
    public class CTO : Handler
    {
        public override void Process(object request)
        {
            if ((request as Employee).expectedSalary <= 15000)
            {
                Console.WriteLine($"Employee {request} is hired by {GetType().Name}!");
            }
            else
            {
                next.Process(request);
            }
        }
    }
}
