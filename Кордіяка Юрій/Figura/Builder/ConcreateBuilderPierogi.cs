namespace Dish
{
    public class ConcreateBuilderPierogi:IDishBuilder
    {
        private Dish pierogi;
        
        public ConcreateBuilderPierogi()
        {
            pierogi = new Dish();
        }
        public void SetPrice()
        {
            pierogi.Price = 250;
        }

        public void SetIngredients()
        {
            pierogi.Ingredient = "flour,water,onion,potato,oil";
        }

        public void SetName()
        {
            pierogi.Name = "Pierogi";
        }

        public void SetSupplements()
        {
            pierogi.Supplements = "mushrooms, buckwheat";
        }

        public Dish GetDish()
        {
            return pierogi;
        }
    }
}