namespace Dish
{
    public interface IDishBuilder
    {
        void SetPrice();
        void SetIngredients();
        void SetName();

        void SetSupplements();
        Dish GetDish();

    }
}