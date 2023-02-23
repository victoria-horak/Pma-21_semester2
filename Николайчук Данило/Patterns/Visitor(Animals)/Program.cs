using Visitor_Animals_.Animals;
using Visitor_Animals_.Visitors;
using Visitor_Animals_;

namespace Visitor_Animals
{
    public class Visitor_Animals
    {
        static void Main()
        {
            IAnimal[] animals = new IAnimal[]
            {
                new Dog("Biggi"),
                new Cat("Murchik"),
                new Bird("Bi-Bi")
            };
            
            Veterinarian vet = new Veterinarian();
            AnimalShelterWorker worker = new AnimalShelterWorker();

            foreach (IAnimal animal in animals)
            {
                animal.Accept(vet);
                animal.Accept(worker);
                Console.WriteLine();
            }
        }
    }
}