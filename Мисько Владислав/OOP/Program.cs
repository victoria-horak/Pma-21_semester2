using System.Linq;

namespace testshit
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            string path = @"D:\Cryptology\FilesWithText\File5.txt";
            string text = System.IO.File.ReadAllText(path);
            System.Console.WriteLine(NormalizeText(text).Length);
        }

        public static string NormalizeText(string text)
        {
            return new string(text.ToLower().Where(_ => char.IsLetter(_)).Select(_ => _).ToArray());
        }

    }
}
