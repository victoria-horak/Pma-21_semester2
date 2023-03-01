using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facade
{
    public interface IRestaurantFacade
    {
        void OrderDessert(string name);
        void OrderBeverage(string name);
    }

   
    public class RestaurantFacade : IRestaurantFacade
    {
      
        private Dessert dessert;
        private Beverage beverage;


        public class Dessert
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

        public RestaurantFacade()
        {
            dessert = new Dessert();
            beverage = new Beverage();
        }
      
        public void OrderDessert(string name)
        {
            dessert.Order(name);
        }

        public void OrderBeverage(string name)
        {
            beverage.Order(name);
        }
    }
}
