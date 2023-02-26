using System;

namespace FlyWeightPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            ParfumeShop shop = new ParfumeShop();
            shop.addParfume(1234, 20, "Chanel", "Flower");
            shop.addParfume(1354, 30, "Chanel", "Flower");
            shop.addParfume(1500, 40, "Gucci", "Muscat");
            shop.addParfume(1674, 50, "Gucci", "Muscat");
            shop.showAll();

        }
    }
}
