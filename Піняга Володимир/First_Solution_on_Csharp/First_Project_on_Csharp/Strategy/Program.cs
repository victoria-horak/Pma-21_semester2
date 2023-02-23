using System;
using System.Runtime.CompilerServices;

namespace Strategy
{
    interface IReader
    {
        void Parse(string url);
    }

    class ResourseReader
    {
        private IReader reader; //стратегія читання даних з ресурсів
        public ResourseReader(IReader reader) { this.reader = reader; }
        public void SetStrategy(IReader reder) => this.reader = reder;
        public void Read(string url) => reader.Parse(url);
    }

    class NewSiteReader: IReader
    {
        public void Parse(string url) => Console.WriteLine("Parsing from newsing site: " + url);
    }

    class SocialNetworkReader: IReader
    {
        public void Parse(string url) => Console.WriteLine("Parsing from social media: " + url);
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            ResourseReader resourseReader = new ResourseReader(new NewSiteReader());

            string url = "https://news.com";
            resourseReader.Read(url);

            url = "https://facebook.com";
            resourseReader.SetStrategy(new SocialNetworkReader());
            resourseReader.Read(url);

        }
    }
}
