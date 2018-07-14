namespace BusinessLayer
{
    /// <summary>
    ///  Burger
    /// </summary>
    public class Burger
    {
        /// <summary>
        /// Burger Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Burger Name
        /// </summary>
        public string Name { get; set; }
        
        /// <summary>
        /// Burger Price
        /// </summary>
        public double Price { get; set; }
       
        /// <summary>
        /// Burger Content
        /// </summary>
        public string Content { get; set; }
        
        /// <summary>
        /// Restaurants Name
        /// </summary>
        public string Restaurant { get; set; }
    }
}
