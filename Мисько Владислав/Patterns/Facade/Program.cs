namespace DesignPattern_Facade
{
    public class Program
    {
        static void Main(string[] args)
        {
            var pupils = PupilsFactory.CreateMultiple();

            FileWriter.WriteToFile(pupils, @"D:\HomeworkC#\demo.txt");
            Console.WriteLine("Done!");
        }
    }
}