using Facade.Facade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facade
{
    public class Client
    {
        private RestaurantFacade _restaurant;

        public Client()
        {
            _restaurant = new RestaurantFacade();
        }

        public void OrderMeal(string dessertName, string beverageName, string pizzaName)
        {
            _restaurant.OrderMeal(dessertName, beverageName, pizzaName);
        }
    }
}
