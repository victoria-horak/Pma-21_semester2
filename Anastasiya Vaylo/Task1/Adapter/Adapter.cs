namespace Adapter
{
  
    interface ICreature
    {
        public void Eat();
    }
    class HumanAdapter : Human, ICreature
    {
        public void Eat()
        {
            Lunch();
        }
    }

    class Human
    {
        public void Lunch()
        {
            System.Console.WriteLine("Eat lunch with knife and fork");
        }
    }

    class AnimalAdapter : Animal, ICreature
    {
        public void Eat()
        {
            Devour();
        }
    }

    class Animal
    {
        public void Devour()
        {
            System.Console.WriteLine("Eat something from the ground with mouth");
        }
    }
}
