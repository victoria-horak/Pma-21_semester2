using System;

namespace Prototype_Pattern
{ 
    internal class Program
    {
        static void Main()
        {
            IRobot robotDonor = new Terminator();
            robotDonor.SetName("T-800");
            IRobot robotClone = robotDonor.clone();
            robotClone.SetName("T-Rex");
            Console.WriteLine("The original: " + robotDonor.GetName());
            Console.WriteLine("The Clone: " + robotClone.GetName());

        }
    }
}
