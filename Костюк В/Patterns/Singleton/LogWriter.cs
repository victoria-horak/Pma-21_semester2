using System;

namespace Singleton
{
    public sealed class LogWriter
    {
        private static LogWriter instance = null;

        private LogWriter()
        {
            Console.WriteLine("Start constructor LogWriter");
        }

        public static LogWriter GetInstance()
        {
            if (instance == null)
            {
                instance = new LogWriter();
            }
            return instance;
        }

        public void WriteToGradebook(string name, string subject, int mark)
        {
            Console.WriteLine($"Start writing: name: {name} subject: {subject} mark: {mark}");
        }
    }
}
