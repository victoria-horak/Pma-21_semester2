using System;

namespace singl
{
    class Program
    {
        static void Main(string[] args)
        {
            Government a = Government.GetInstance();
            Government b = Government.GetInstance();

            a.IncreaseBudget();
            a.IncreaseBudget();
            int x = b.GetBudget();
            System.Console.WriteLine("The budget is " + x );
        }
    }
}
