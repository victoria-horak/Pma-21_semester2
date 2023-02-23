using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visitor_Animals_
{
    internal interface IAnimal
    {
        void Accept(IAnimalVisitor visitor);
        string Name { get; set; }
        void tellAboutItSelf();
    }
}
