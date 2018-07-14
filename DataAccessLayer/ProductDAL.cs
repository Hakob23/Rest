namespace DAL
{
    /// <summary>
    /// DAL Product
    /// </summary>
    public class ProductDAL
    {
        /// <summary>
        /// id of product
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Name of product
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Category of product
        /// </summary>
        public string Category { get; set; }
        
        /// <summary>
        /// Price of product
        /// </summary>
        public double Price { get; set; }
    }
}
