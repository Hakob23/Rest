namespace DAL
{
    /// <summary>
    ///  HotMeal DAL
    /// </summary>
    public class HotMealDAL
    {
        /// <summary>
        /// Hot Meal Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Hot Meal Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Hot Meal Price
        /// </summary>
        public double Price { get; set; }

        /// <summary>
        /// Hot Meal Content
        /// </summary>
        public string Content { get; set; }
        
        /// <summary>
        /// Restaurants Name
        /// </summary>
        public string Restaurant { get; set; }
    }
}
