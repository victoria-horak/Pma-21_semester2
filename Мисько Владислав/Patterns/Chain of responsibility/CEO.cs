namespace DesignPattern_ChainOfResponsibility
{
    public class CEO : Handler
    {
        public override void Process(object request)
        {
            if (request is not Employee)
            {
                Console.WriteLine("Invalid data about employee!");
                return;
            }
            if ((request as Employee).expectedSalary <= 10000)
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
