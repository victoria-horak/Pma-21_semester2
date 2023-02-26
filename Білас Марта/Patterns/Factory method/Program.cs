using System;

namespace FactoryMethodPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Client client = new Client();
            client.initialize("Platinum");
            client.show();
        }
    }
}
