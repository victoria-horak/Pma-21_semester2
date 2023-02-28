
namespace singl
{
    public class Government
    {
        private Government() { }
        private static Government _government;
        private int _budget = 0;

        public static Government GetInstance()
        {
            if (_government == null)
            {
                _government = new Government();
            }
            return _government;
        }
        public void IncreaseBudget()
        {
            _budget = _budget + 10;
        }
        public void DecreaseBudget()
        {
            _budget = _budget - 10;
        }
        public int GetBudget()
        {
            return _budget;
        }

    }
}
