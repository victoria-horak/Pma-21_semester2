namespace BehavioralPatterns.Strategy
{
    internal class RainingWearingStrategy : IWearingStrategy
    {
        public string GetClothes()
        {
            return "jacket";
        }
        public string GetAccessories()
        {
            return "umbrella";
        }
    }

}
