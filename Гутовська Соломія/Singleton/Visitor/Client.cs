using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visitor
{
    public class Client : IAnimalVisitor
    {
        public void Visit(Cat cat)
        {
            Console.WriteLine("Client visits cat.");
        }

        public void Visit(Turtle turtle)
        {
            Console.WriteLine("Client visits turtle.");
        }

        public void Visit(Koala koala)
        {
            Console.WriteLine("Client visits koala.");
        }
    }
}
