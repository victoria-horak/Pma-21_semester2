namespace StructuralPatterns.Bridge
{
    public class BrickWallCreator : IWallCreator
    {
        public void BuildWall()
        {
            Console.WriteLine("Brick wall.");
        }

        public void BuildWallWithDoor()
        {
            Console.WriteLine("Brick wall with door.");
        }

        public void BuildWallWithWindow()
        {
            Console.WriteLine("Brick wall with window.");
        }
    }
}
