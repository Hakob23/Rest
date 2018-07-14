namespace DAL
{
    /// <summary>
    ///  Pizza DAL
    /// </summary>
    public class PizzaDAL
    {
        /// <summary>
        /// Pizza Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Pizza Name
        /// </summary>
        public string Name { get; set; }
        
        /// <summary>
        /// Pizza Price
        /// </summary>
        public double Price { get; set; }
       
        /// <summary>
        /// Pizzas Content
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// Pizzas Diametr
        /// </summary>
        public int Diametr { get; set; }

        /// <summary>
        /// Restaurants Name
        /// </summary>
        public string Restaurant { get; set; }
    }
}
