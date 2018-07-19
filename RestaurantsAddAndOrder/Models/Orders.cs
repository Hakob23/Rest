using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantsAddAndOrder.Models
{
    public class Orders
    {
        public int TableID { get; set; }
        public string RestaurantName { get; set; }
        public string OrderCategory { get; set; }
        public int MealID { get; set; }
        public int Quantity { get; set; }
        public string Messege { get; set; }

    }
}
