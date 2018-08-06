namespace RestaurantsAddAndOrder.Models
{
    public class Orders
    {
        public int TableID { get; set; }
        public string Restaurant { get; set; }
        public string OrderCategory { get; set; }
        public int MealID { get; set; }
        public int Quantity { get; set; }
        public string Messege { get; set; }
        public string Address { get; set; }
        public double Price { get; set; }
    }
}
