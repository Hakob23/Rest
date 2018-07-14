namespace DAL
{
    /// <summary>
    ///  Soup DAL
    /// </summary>
    public class SoupDAL
    {
        /// <summary>
        /// Soup Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Soup Name
        /// </summary>
        public string Name { get; set; }
        
        /// <summary>
        /// Soup Price
        /// </summary>
        public double Price { get; set; }
       
        /// <summary>
        /// Soup Content
        /// </summary>
        public string Content { get; set; }
        
        /// <summary>
        /// Restaurants Name
        /// </summary>
        public string Restaurant { get; set; }
    }
}
