namespace BehavioralPatterns.Strategy
{
    internal class DefaultWearingStrategy : IWearingStrategy
    {
        public string GetClothes() 
        {
            return "T-shirt and jeans";
        }
        public string GetAccessories()
        {
            return "watch";
        }
    }

}
