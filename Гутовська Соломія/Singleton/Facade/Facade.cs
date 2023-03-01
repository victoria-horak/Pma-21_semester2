namespace Facade{
        public class RestaurantFacade
        {
            private Dessert dessert;
            private Beverage beverage;
            private Pizza pizza;

            public RestaurantFacade()
            {
                dessert = new Dessert();
                beverage = new Beverage();
                pizza = new Pizza();
            }

            public void OrderMeal(string dessertName, string beverageName, string pizzaName)
            {
                dessert.Order(dessertName);
                beverage.Order(beverageName);
                pizza.Order(pizzaName);
            }

            private class Dessert
            {
                public void Order(string name)
                {
                    Console.WriteLine($"Ordering dessert {name}.");
                }
            }

            private class Beverage
            {
                public void Order(string name)
                {
                    Console.WriteLine($"Ordering beverage {name}.");
                }
            }

            private class Pizza
            {
                public void Order(string name)
                {
                    Console.WriteLine($"Ordering pizza {name}.");
                }
            }
        }
    }
