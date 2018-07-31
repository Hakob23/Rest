namespace KushtPor.Models
{
    /// <summary>
    /// Order class
    /// </summary>
    public class Order
    {
        /// <summary>
        /// Tables Id
        /// </summary>
        public int TableId { get; set; }

        /// <summary>
        /// Restaurant name
        /// </summary>
        public string Restaurant { get; set; }

        /// <summary>
        /// Order Category
        /// </summary>
        public string OrderCategory { get; set; }

        /// <summary>
        /// Meal Id
        /// </summary>
        public int MealId { get; set; }

        /// <summary>
        /// Quantity
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Messege
        /// </summary>
        public string Messege { get; set; }
    }
}
