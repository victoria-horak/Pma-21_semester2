using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facade
{
    public class Client
    {
        private IRestaurantFacade _restaurant;

        public Client(IRestaurantFacade restaurant)
        {
            _restaurant = restaurant;
        }

        public void OrderMeal( string dessertName, string beverageName)
        {
            _restaurant.OrderDessert(dessertName);
            _restaurant.OrderBeverage(beverageName);
        }
    }
}
