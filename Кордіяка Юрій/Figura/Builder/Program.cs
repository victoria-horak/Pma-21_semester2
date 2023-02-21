using System;

namespace Dish
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            IDishBuilder idishBuilder = new ConcreateBuilderBorsh();
            ChefDirector chefDirector = new ChefDirector(idishBuilder);
            Dish borsh = chefDirector.CookDishWithSupplements();
            Console.WriteLine("Borsh:\n" + "Ingredients : "+borsh.Ingredient + "\nName : "+ borsh.Name +"\nPrice : " + borsh.Price+"\nSupplements : "+borsh.Supplements+"\n");


            IDishBuilder idishBuilder2 = new ConcreateBuilderPierogi();
            ChefDirector chefDirector2 = new ChefDirector(idishBuilder2);
            Dish pierogi = chefDirector2.CookDishWithoutSupplements();
            Console.WriteLine("Pierogi:\n" + "Ingredients : " +pierogi.Ingredient + "\nName : "+ pierogi.Name +"\nPrice : " +pierogi.Price+"\n");
            
        }
    }
}