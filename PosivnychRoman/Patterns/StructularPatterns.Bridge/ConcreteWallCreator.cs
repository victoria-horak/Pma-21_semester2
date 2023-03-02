namespace StructuralPatterns.Bridge
{
    public class ConcreteWallCreator : IWallCreator
    {
        public void BuildWall()
        {
            Console.WriteLine("Concrete wall.");
        }

        public void BuildWallWithDoor()
        {
            Console.WriteLine("Concrete wall with door.");
        }

        public void BuildWallWithWindow()
        {
            Console.WriteLine("Concrete wall with window.");
        }
    }
}
