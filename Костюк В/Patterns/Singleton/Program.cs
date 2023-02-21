using System;

class Program
{
    static void Main(string[] args)
    {
        var logger = Singleton.LogWriter.GetInstance();
        logger.WriteToGradebook("Vitaliy", "Proga", 5);
        logger.WriteToGradebook("Taras", "Eng", 4);
    }
}