namespace StructuralPatterns.Bridge
{
    class BuildingCompany : IBuildingCompany
    {
        public void BuildFoundation()
        {
            Console.WriteLine("Foundation is built.{0}", Environment.NewLine);
        }

        public void BuildRoom()
        {
            WallCreator.BuildWallWithDoor();
            WallCreator.BuildWall();
            WallCreator.BuildWallWithWindow();
            WallCreator.BuildWall();
            Console.WriteLine("Room finished.{0}", Environment.NewLine);
        }
        public void BuildRoof()
        {
            Console.WriteLine("Roof is done.{0}", Environment.NewLine);
        }
        public IWallCreator WallCreator { get; set; }
    }
}
