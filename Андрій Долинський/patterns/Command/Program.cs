using Command;

class Program
{
    static void Main(string[] args)
    {
        Receiver receiver = new Receiver();

        ICommand command1 = new ConcreteCommand(receiver, "command 1");
        ICommand command2 = new ConcreteCommand(receiver, "command 2");

        Invoker invoker = new Invoker();

        invoker.SetCommand(command1);

        invoker.ExecuteCommand();

        invoker.SetCommand(command2);

        invoker.ExecuteCommand();
    }
}