namespace StructuralPatterns.Bridge
{
    public interface IBuildingCompany
    {
        void BuildFoundation();
        void BuildRoom();
        void BuildRoof();
        IWallCreator WallCreator { get; set; }
    }
}
