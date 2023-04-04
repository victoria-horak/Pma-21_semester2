using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visitor
{
    public interface IAnimal
    {
        void Accept(IAnimalVisitor visitor);
    }
}
