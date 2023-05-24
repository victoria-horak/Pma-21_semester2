using StructularPattern.Decorate_;

internal class Program
{
    private static void Main(string[] args)
    {
        var humanCar = new MilitaryCar(new Audi());
        humanCar.Go();
        var humanCar2 = new AmbulanceCar(new Audi());
        humanCar2.Go();
        var humanCar3 = new MilitaryCar(new AmbulanceCar(new Audi()));
        humanCar3.Go();
    }
}