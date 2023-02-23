using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Visitor_Animals_.Animals;

namespace Visitor_Animals_.Visitors
{
    internal class AnimalShelterWorker : IAnimalVisitor
    {
        public void Visit(Dog dog)
        {
            Console.WriteLine("The animal shelter worker feeds the dog.");
            dog.tellAboutItSelf();
        }
        public void Visit(Cat cat)
        {
            Console.WriteLine("The animal shelter worker plays with the cat.");
            cat.tellAboutItSelf();
        }
        public void Visit(Bird bird)
        {
            Console.WriteLine("The animal shelter worker cleans the bird's cage.");
            bird.tellAboutItSelf();
        }
    }
}
