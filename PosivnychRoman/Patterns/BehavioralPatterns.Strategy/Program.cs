using BehavioralPatterns.Strategy;

internal class Program
{
    private static void Main(string[] args)
    {
        var Roman = new Myself();
        Roman.GoOutide();

        Console.WriteLine("Today is raining.");

        Roman.ChangeStrategy(new RainingWearingStrategy());

        Roman.GoOutide();

        Console.WriteLine("Today is sunny.");

        Roman.ChangeStrategy(new SunshineWearingStrategy());

        Roman.GoOutide();
    }
}