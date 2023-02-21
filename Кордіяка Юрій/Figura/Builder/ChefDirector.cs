namespace Dish
{
    public class ChefDirector
    {
        private IDishBuilder idishbuilder;

        public ChefDirector(IDishBuilder idishbuilder)
        {
            this.idishbuilder = idishbuilder;
        }

        public Dish CookDishWithSupplements()
        {
            idishbuilder.SetName();
            idishbuilder.SetIngredients();
            idishbuilder.SetPrice();
            idishbuilder.SetSupplements();
            return idishbuilder.GetDish();
        }
        public Dish CookDishWithoutSupplements()
        {
            idishbuilder.SetName();
            idishbuilder.SetIngredients();
            idishbuilder.SetPrice();
            return idishbuilder.GetDish();
        }
    }
}