using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Visitor_Animals_.Animals;

namespace Visitor_Animals_
{
    internal interface IAnimalVisitor
    {
        void Visit(Dog dog);
        void Visit(Cat cat);
        void Visit(Bird bird);
    }
}
