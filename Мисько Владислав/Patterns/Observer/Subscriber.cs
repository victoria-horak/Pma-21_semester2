namespace DesignPattern_Observer
{
    public class Subscriber : ISubscriber
    {
        public string name { get; set; }
        public string surname { get; set; }

        public Subscriber(string name, string surname)
        {
            this.name = name;
            this.surname = surname;
        }   

        public void Update(object context)
        {
            Console.WriteLine($"notification for {name} {surname}: new state of subscription: {context}");
        }
    }
}