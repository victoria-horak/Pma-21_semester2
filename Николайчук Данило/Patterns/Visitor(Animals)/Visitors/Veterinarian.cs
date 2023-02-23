using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Visitor_Animals_.Animals;

namespace Visitor_Animals_.Visitors
{
    internal class Veterinarian:IAnimalVisitor
    {
        public void Visit(Dog dog)
        {
            Console.WriteLine("The veterinarian examines the dog.");
            dog.tellAboutItSelf();
        }
        public void Visit(Cat cat)
        {
            Console.WriteLine("The veterinarian examines the cat.");
            cat.tellAboutItSelf();
        }
        public void Visit(Bird bird)
        {
            Console.WriteLine("The veterinarian examines the bird.");
            bird.tellAboutItSelf();
        }
    }
}
