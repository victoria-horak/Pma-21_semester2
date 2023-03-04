namespace DesignPattern_Builder
{
    public class Program
    {
        static void Main(string[] args)
        {
            CarBuilder carBuilder = new CarBuilder();

            Director<Car>.ConstructSportsCar(carBuilder);

            CarManualBuilder carManualBuilder = new CarManualBuilder();
            
            Director<CarManual>.ConstructSportsCar(carManualBuilder);

            CarManual sportsCarManual = carManualBuilder.giveReadyProduct();

            Console.WriteLine(sportsCarManual);

            Console.WriteLine("---------------------------");

            Director<Car>.ConstructOldCar(carBuilder);

            Director<CarManual>.ConstructOldCar(carManualBuilder);

            CarManual oldCarManual = carManualBuilder.giveReadyProduct();

            Console.WriteLine(oldCarManual);

        }
    }
}