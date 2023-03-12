using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visitor
{
    public class Cat : IAnimal
    {
        public void Accept(IAnimalVisitor visitor)
        {
            visitor.Visit(this);
        }
    }

    public class Turtle : IAnimal
    {
        public void Accept(IAnimalVisitor visitor)
        {
            visitor.Visit(this);
        }
    }

    public class Koala : IAnimal
    {
        public void Accept(IAnimalVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
