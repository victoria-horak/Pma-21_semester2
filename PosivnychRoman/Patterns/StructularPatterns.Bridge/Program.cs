namespace StructuralPatterns.Bridge
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var buildingCompany = new BuildingCompany();
            buildingCompany.BuildFoundation();

            var brickWallCreator = new BrickWallCreator();
            buildingCompany.WallCreator = brickWallCreator;
            buildingCompany.BuildRoom();
            buildingCompany.BuildRoom();
            buildingCompany.BuildRoom();

            var concreteWallCreator = new ConcreteWallCreator();
            buildingCompany.WallCreator = concreteWallCreator;
            buildingCompany.BuildRoom();

            buildingCompany.WallCreator = null;
            buildingCompany.BuildRoof();
        }
    }
}
