namespace KushtPor.ViewModels
{
    /// <summary>
    /// Pizzas View Model
    /// </summary>
    class PizzaPublicInfo
    {
        // name

        public string Name { get; set; }

        // price
        public double Price { get; set; }

        // any content

        public string Content { get; set; }

        // Diametr
        public int Diametr { get; set; }

        ///// <summary>
        ///// username and accessToken
        ///// </summary>
        //string username, accessToken;
        //public PizzaViewModel(string accessToken, string username)
        //{
        //    this.username = username;
        //    this.accessToken = accessToken;
        //}
    }
}
