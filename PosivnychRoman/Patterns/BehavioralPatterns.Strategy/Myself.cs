namespace BehavioralPatterns.Strategy
{
    class Myself
    {
        private IWearingStrategy _wearingStrategy = new DefaultWearingStrategy();
        public void ChangeStrategy(IWearingStrategy wearingStrategy)
        {
            _wearingStrategy = wearingStrategy;
        }
        public void GoOutide()
        {
            var clothes = _wearingStrategy.GetClothes();
            var accessories = _wearingStrategy.GetAccessories();
            Console.WriteLine($"Today I wore {clothes} and took {accessories}");
        }
    }

}
