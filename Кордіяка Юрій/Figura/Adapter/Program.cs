using System;

namespace Adapter
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            double celsius = 33;
            double fahrenheit = 33;
            IDegrees dcelsius = new DegreesCelsius(celsius);
            IDegrees dfahrenheit = new AdapterForDegreesFahrenheit(new DegreesFahrenheit(fahrenheit));
            Console.WriteLine(dcelsius.GetDegrees());
            Console.WriteLine(dfahrenheit.GetDegrees());
        }
    }
}