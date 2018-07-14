using DAL;
using System.Collections.Generic;

namespace BusinessLayer
{
    /// <summary>
    /// Business Layer
    /// </summary>
    public class ProductsRepository
    {
        /// <summary>
        /// Static DAL object
        /// </summary>
        private readonly DataAccessLayer dal;
        
        /// <summary>
        /// Creates a new Products repository
        /// </summary>
        public ProductsRepository()
        {
            this.dal = new DataAccessLayer();
        }
        
        /// <summary>
        /// Static method Returns all Ts with restaurant Name
        /// </summary>
        /// <returns>products</returns>
        public IEnumerable<T> Get<T>(string restaurantName)
        {
            List<T> products = new List<T>();
            switch (typeof(T).Name.ToString())
            {
                case "AlcoholDrink":
                    foreach (var item in dal.Get<AlcoholDrinkDAL>(restaurantName))
                    {
                        var mapper2 = new ReflectionBasedMapper<AlcoholDrinkDAL, T>();
                        products.Add(mapper2.Map(item));
                    }
                    break;
                case "Burger":
                    foreach (var item in dal.Get<BurgerDAL>(restaurantName))
                    {
                        var mapper2 = new ReflectionBasedMapper<BurgerDAL, T>();
                        products.Add(mapper2.Map(item));
                    }
                    break;
                case "Drink":
                    foreach (var item in dal.Get<DrinkDAL>(restaurantName))
                    {
                        var mapper2 = new ReflectionBasedMapper<DrinkDAL, T>();
                        products.Add(mapper2.Map(item));
                    }
                    break;
                case "HotMeal":
                    foreach (var item in dal.Get<HotMealDAL>(restaurantName))
                    {
                        var mapper2 = new ReflectionBasedMapper<HotMealDAL, T>();
                        products.Add(mapper2.Map(item));
                    }
                    break;
                case "Pizza":
                    foreach (var item in dal.Get<PizzaDAL>(restaurantName))
                    {
                        var mapper2 = new ReflectionBasedMapper<PizzaDAL, T>();
                        products.Add(mapper2.Map(item));
                    }
                    break;
                case "Salad":
                    foreach (var item in dal.Get<SaladDAL>(restaurantName))
                    {
                        var mapper2 = new ReflectionBasedMapper<SaladDAL, T>();
                        products.Add(mapper2.Map(item));
                    }
                    break;
                case "Soup":
                    foreach (var item in dal.Get<SoupDAL>(restaurantName))
                    {
                        var mapper2 = new ReflectionBasedMapper<SoupDAL, T>();
                        products.Add(mapper2.Map(item));
                    }
                    break;
            }
            return products;
        }

        /// <summary>
        /// Static method Returns all Ts
        /// </summary>
        /// <returns>products</returns>
        public IEnumerable<T> GetAll<T>()
        {
            List<T> products = new List<T>();
            switch (typeof(T).Name.ToString())
            {
                case "AlcoholDrink":
                    foreach (var item in dal.GetAll<AlcoholDrinkDAL>())
                    {
                        var mapper2 = new ReflectionBasedMapper<AlcoholDrinkDAL, T>();
                        products.Add(mapper2.Map(item));
                    }
                    break;
                case "Burger":
                    foreach (var item in dal.GetAll<BurgerDAL>())
                    {
                        var mapper2 = new ReflectionBasedMapper<BurgerDAL, T>();
                        products.Add(mapper2.Map(item));
                    }
                    break;
                case "Drink":
                    foreach (var item in dal.GetAll<DrinkDAL>())
                    {
                        var mapper2 = new ReflectionBasedMapper<DrinkDAL, T>();
                        products.Add(mapper2.Map(item));
                    }
                    break;
                case "HotMeal":
                    foreach (var item in dal.GetAll<HotMealDAL>())
                    {
                        var mapper2 = new ReflectionBasedMapper<HotMealDAL, T>();
                        products.Add(mapper2.Map(item));
                    }
                    break;
                case "Pizza":
                    foreach (var item in dal.GetAll<PizzaDAL>())
                    {
                        var mapper2 = new ReflectionBasedMapper<PizzaDAL, T>();
                        products.Add(mapper2.Map(item));
                    }
                    break;
                case "Salad":
                    foreach (var item in dal.GetAll<SaladDAL>())
                    {
                        var mapper2 = new ReflectionBasedMapper<SaladDAL, T>();
                        products.Add(mapper2.Map(item));
                    }
                    break;
                case "Soup":
                    foreach (var item in dal.GetAll<SoupDAL>())
                    {
                        var mapper2 = new ReflectionBasedMapper<SoupDAL, T>();
                        products.Add(mapper2.Map(item));
                    }
                    break;
            }
            return products;
        }
        
        /// <summary>
        /// Creates product
        /// </summary>
        /// <param name="product"> product</param>
        /// <returns>true if successfully added</returns>
        public bool CreateProduct<T>(T product)
        {
            bool added = false;
            switch (typeof(T).Name.ToString())
            {
                case "AlcoholDrink":
                    {
                        var mapper2 = new ReflectionBasedMapper<AlcoholDrinkDAL, T>();
                        added = dal.AddProduct(mapper2.MapBack(product));
                        break;
                    }

                case "Burger":
                    {
                        var mapper2 = new ReflectionBasedMapper<BurgerDAL, T>();
                        added = dal.AddProduct(mapper2.MapBack(product));
                        break;
                    }
                case "Drink":
                    {
                        var mapper2 = new ReflectionBasedMapper<DrinkDAL, T>();
                        added = dal.AddProduct(mapper2.MapBack(product));
                        break;
                    }
                case "HotMeal":
                    {
                        var mapper2 = new ReflectionBasedMapper<HotMealDAL, T>();
                        added = dal.AddProduct(mapper2.MapBack(product));
                        break;
                    }
                case "Pizza":
                    {
                        var mapper2 = new ReflectionBasedMapper<PizzaDAL, T>();
                        added = dal.AddProduct(mapper2.MapBack(product));
                        break;
                    }
                case "Salad":
                    {
                        var mapper2 = new ReflectionBasedMapper<SaladDAL, T>();
                        added = dal.AddProduct(mapper2.MapBack(product));
                        break;
                    }
                case "Soup":
                    {
                        var mapper2 = new ReflectionBasedMapper<SoupDAL, T>();
                        added = dal.AddProduct(mapper2.MapBack(product));
                        break;
                    }
            }
            return added;
        }

        /// <summary>
        /// Updates product
        /// </summary>
        /// <param name="product">product</param>
        /// <returns>true if successfully updated</returns>
        public bool UpdateProduct<T>(T product)
        {
            bool updated = false;
            switch (typeof(T).Name.ToString())
            {
                case "AlcoholDrink":
                    {
                        var mapper2 = new ReflectionBasedMapper<AlcoholDrinkDAL, T>();
                        updated = dal.UpdateProduct(mapper2.MapBack(product));
                        break;
                    }

                case "Burger":
                    {
                        var mapper2 = new ReflectionBasedMapper<BurgerDAL, T>();
                        updated = dal.UpdateProduct(mapper2.MapBack(product));
                        break;
                    }
                case "Drink":
                    {
                        var mapper2 = new ReflectionBasedMapper<DrinkDAL, T>();
                        updated = dal.UpdateProduct(mapper2.MapBack(product));
                        break;
                    }
                case "HotMeal":
                    {
                        var mapper2 = new ReflectionBasedMapper<HotMealDAL, T>();
                        updated = dal.UpdateProduct(mapper2.MapBack(product));
                        break;
                    }
                case "Pizza":
                    {
                        var mapper2 = new ReflectionBasedMapper<PizzaDAL, T>();
                        updated = dal.UpdateProduct(mapper2.MapBack(product));
                        break;
                    }
                case "Salad":
                    {
                        var mapper2 = new ReflectionBasedMapper<SaladDAL, T>();
                        updated = dal.UpdateProduct(mapper2.MapBack(product));
                        break;
                    }
                case "Soup":
                    {
                        var mapper2 = new ReflectionBasedMapper<SoupDAL, T>();
                        updated = dal.UpdateProduct(mapper2.MapBack(product));
                        break;
                    }
            }
            return updated;
        }
        
        /// <summary>
        /// Deletes product
        /// </summary>
        /// <param name="product">product</param>
        /// <returns>true if successfully deleted</returns>
        public bool DeleteProduct<T>(T product)
        {
            bool deleted = false;
            switch (typeof(T).Name.ToString())
            {
                case "AlcoholDrink":
                    {
                        var mapper2 = new ReflectionBasedMapper<AlcoholDrinkDAL, T>();
                        deleted = dal.UpdateProduct(mapper2.MapBack(product));
                        break;
                    }

                case "Burger":
                    {
                        var mapper2 = new ReflectionBasedMapper<BurgerDAL, T>();
                        deleted = dal.UpdateProduct(mapper2.MapBack(product));
                        break;
                    }
                case "Drink":
                    {
                        var mapper2 = new ReflectionBasedMapper<DrinkDAL, T>();
                        deleted = dal.UpdateProduct(mapper2.MapBack(product));
                        break;
                    }
                case "HotMeal":
                    {
                        var mapper2 = new ReflectionBasedMapper<HotMealDAL, T>();
                        deleted = dal.UpdateProduct(mapper2.MapBack(product));
                        break;
                    }
                case "Pizza":
                    {
                        var mapper2 = new ReflectionBasedMapper<PizzaDAL, T>();
                        deleted = dal.UpdateProduct(mapper2.MapBack(product));
                        break;
                    }
                case "Salad":
                    {
                        var mapper2 = new ReflectionBasedMapper<SaladDAL, T>();
                        deleted = dal.UpdateProduct(mapper2.MapBack(product));
                        break;
                    }
                case "Soup":
                    {
                        var mapper2 = new ReflectionBasedMapper<SoupDAL, T>();
                        deleted = dal.UpdateProduct(mapper2.MapBack(product));
                        break;
                    }
            }
            return deleted;
        }
    }
}
