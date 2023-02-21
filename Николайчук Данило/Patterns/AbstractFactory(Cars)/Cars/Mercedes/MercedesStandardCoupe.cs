using AbstractFactory_Cars_.CarsInterface;

namespace AbstractFactory_Cars_.Cars.Mercedes
{
    internal class MercedesStandardCoupe : ICoupe
    {
        public string GetName()
        {
            return "Mercedes amg gt";
        }
        public int GetPrice()
        {
            return 100000;
        }
        public void Drive()
        {
            Console.WriteLine("Driving a Mercedes amg gt");
        }
    }
}