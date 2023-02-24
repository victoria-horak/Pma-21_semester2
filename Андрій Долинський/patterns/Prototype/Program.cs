using Prototype;
class Program
{
    static void Main(string[] args)
    {
        User user1 = new User("John", "john@example.com", "password123");

        User user2 = user1.Clone() as User;
        user2.Name = "Andriy";
        user2.Email = "andriy@example.com";
        user2.Password = "password321";

        Console.WriteLine("User 1: " + user1.Name + " " + user1.Email + " " + user1.Password);
        Console.WriteLine("User 2: " + user2.Name + " " + user2.Email + " " + user2.Password);
    }
}

