namespace BehavioralPatterns.Strategy
{
    internal class SunshineWearingStrategy : IWearingStrategy
    {
        public string GetAccessories()
        {
            return "sunglosses";
        }

        public string GetClothes()
        {
            return "cap";
        }
    }
}
