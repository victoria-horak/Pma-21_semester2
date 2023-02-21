using AbstractFactory_Cars_.CarsInterface;

namespace AbstractFactory_Cars_.Cars.Mercedes
{
    internal class MercedesHighCoupe : ICoupe
    {
        public string GetName()
        {
            return "Mercedes s-class coupe";
        }
        public int GetPrice()
        {
            return 130000;
        }
        public void Drive()
        {
            Console.WriteLine("Driving a Mercedes s-class coupe");
        }
    }
}