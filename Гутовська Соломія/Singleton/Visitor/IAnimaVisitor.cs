using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visitor
{
    public interface IAnimalVisitor
    {
        void Visit(Cat cat);
        void Visit(Turtle turtle);
        void Visit(Koala koala);
    }
}
