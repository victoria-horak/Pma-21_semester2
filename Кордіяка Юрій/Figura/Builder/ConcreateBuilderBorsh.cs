namespace Dish
{
    public class ConcreateBuilderBorsh : IDishBuilder
    {
        private Dish borsh;

        public ConcreateBuilderBorsh()
        {
            borsh = new Dish();
        }

        public void SetPrice()
        {
            borsh.Price = 300;
        }

        public void SetIngredients()
        {
            borsh.Ingredient =
                "beetroot carrots potatoes greens cabbage salt powder pepper sunflower oil onion  meat  tomatoes or tomato paste ";
        }

        public void SetName()
        {
            borsh.Name = "Borsh";
        }

        public void SetSupplements()
        {
            borsh.Supplements = "coriander,Celery";
        }

        public Dish GetDish()
        {
            return borsh;
        }
    }
}