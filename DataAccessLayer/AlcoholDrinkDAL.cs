namespace DAL
{
    /// <summary>
    /// Alcoholic Drink DAL
    /// </summary>
    public class AlcoholDrinkDAL
    {
        /// <summary>
        /// Drinks Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Driks Name
        /// </summary>
        public string Name { get; set; }
        
        /// <summary>
        /// Driks Price
        /// </summary>
        public double Price { get; set; }
        
        /// <summary>
        /// Driks Alcohol Procents
        /// </summary>
        public double Alcohol { get; set; }
        
        /// <summary>
        /// Driks Volume
        /// </summary>
        public double Volume { get; set; }
        
        /// <summary>
        /// Restaurants Name
        /// </summary>
        public string Restaurant { get; set; }
    }
}
