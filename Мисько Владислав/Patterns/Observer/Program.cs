namespace DesignPattern_Observer
{
    public class Program
    {
        static void Main(string[] args)
        {
            Publisher publisher = new Publisher();
            Subscriber firstSubscriber = new Subscriber("John", "Cena");
            Subscriber secondSubscriber = new Subscriber("Randy", "Orton");

            publisher.subscribe(firstSubscriber);
            publisher.subscribe(secondSubscriber);
            publisher.updateState("available");
            Console.WriteLine("---------");
            publisher.updateState("unavailable");
            Console.WriteLine("---------");
            publisher.unsubscribe(firstSubscriber);
            publisher.updateState("available");
            Console.WriteLine("---------");

        }
    }
}