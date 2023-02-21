using AbstractFactory_Cars_.CarsInterface;

namespace AbstractFactory_Cars_.Cars.Mercedes
{
    internal class MercedesLowCoupe : ICoupe
    {
        public string GetName()
        {
            return "Mercedes c-class coupe";
        }
        public int GetPrice()
        {
            return 45000;
        }
        public void Drive()
        {
            Console.WriteLine("Driving a Mercedes c-class coupe");
        }
    }
}