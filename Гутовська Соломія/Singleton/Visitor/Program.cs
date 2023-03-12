using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visitor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var cat = new Cat();
            var turtle = new Turtle();
            var koala = new Koala();

            var client = new Client();

            cat.Accept(client);
            turtle.Accept(client);
            koala.Accept(client);

        }
    }
}
