using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facade
{
    public class Program
    {
        static void Main(string[] args)
        {
            var restaurant = new RestaurantFacade();
            var client = new Client(restaurant);

            client.OrderMeal("Chocolate cake", "Water");
        }
    }
}
