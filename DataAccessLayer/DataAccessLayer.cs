using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System;
using System.IO;
using Microsoft.Extensions.Configuration;

namespace DAL
{
    /// <summary>
    /// DataAccessLayer Class
    /// </summary>
    public class DataAccessLayer
    {
        /// <summary>
        /// The connection string 
        /// </summary>
        private string connectionString;

        /// <summary>
        /// DataAccessLayer Controller
        /// </summary>
        public DataAccessLayer()
        {
            var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json");
            
            var config = builder.Build();

            connectionString = config.GetSection("ConnectionStrings").GetSection("RestaurantsConnection").Value;
            //this.connectionString = System.Configuration.GetConnectionString("DefaultConnection");
            //this.connectionString = ConfigurationManager.ConnectionStrings["RestaurantsConnection"].ConnectionString; 
        }

        /// <summary>
        /// Returns all Ts with restaurant name as IEnumerable 
        /// </summary>
        /// <returns>All Alcohol Drinks</returns>
        public IEnumerable<T> Get<T>(string restaurantName)
        {
            string table = null;
            switch (typeof(T).Name.ToString())
            {
                case "BurgerDAL":
                    table = "Burgers";
                    break;
                case "AlcoholDrinkDAL":
                    table = "AlcoholDrinks";
                    break;
                case "DrinkDAL":
                    table = "Drinks";
                    break;
                case "HotMealDAL":
                    table = "HotMeals";
                    break;
                case "PizzaDAL":
                    table = "Pizzas";
                    break;
                case "SaladDAL":
                    table = "Salads";
                    break;
                case "SoupDAL":
                    table = "Soups";
                    break;
            }
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand
                {
                    CommandType = CommandType.Text,
                    CommandText = $"select * from {table} Where Restaurant = '{restaurantName}'",
                    Connection = connection
                };
                
                // products list
                List<T> products = new List<T>();
                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader()) 
                {
                    while (reader.Read())
                    {
                        var instance = Activator.CreateInstance<T>();
                        foreach (var prop in typeof(T).GetProperties())
                        {
                            prop.SetValue(instance, Convert.ChangeType(reader[prop.Name], prop.PropertyType));
                        }
                        // Create product
                        products.Add(instance);
                    }
                }

                // return product
                return products;
            }
        }

        /// <summary>
        /// Returns all Ts as IEnumerable 
        /// </summary>
        /// <returns>All Alcohol Drinks</returns>
        public IEnumerable<T> GetAll<T>()
        {
            string table = null;
            switch (typeof(T).Name.ToString())
            {
                case "BurgerDAL":
                    table = "Burgers";
                    break;
                case "AlcoholDrinkDAL":
                    table = "AlcoholDrinks";
                    break;
                case "DrinkDAL":
                    table = "Drinks";
                    break;
                case "HotMealDAL":
                    table = "HotMeals";
                    break;
                case "PizzaDAL":
                    table = "Pizzas";
                    break;
                case "SaladDAL":
                    table = "Salads";
                    break;
                case "SoupDAL":
                    table = "Soups";
                    break;
            }
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand
                {
                    CommandType = CommandType.Text,
                    CommandText = $"select * from {table}",
                    Connection = connection
                };

                // products list
                List<T> products = new List<T>();
                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var instance = Activator.CreateInstance<T>();
                        foreach (var prop in typeof(T).GetProperties())
                        {
                            prop.SetValue(instance, Convert.ChangeType(reader[prop.Name], prop.PropertyType));
                        }
                        // Create product
                        products.Add(instance);
                    }
                }

                // return product
                return products;
            }
        }

        /// <summary>
        /// Add Product
        /// </summary>
        /// <param name="product">product</param>
        /// <returns>true if successfully added</returns>
        public bool AddProduct<T>(T product)
        {
            string table = null;
            switch (typeof(T).Name.ToString())
            {
                case "BurgerDAL":
                    table = "Burgers";
                    break;
                case "AlcoholDrinkDAL":
                    table = "AlcoholDrinks";
                    break;
                case "DrinkDAL":
                    table = "Drinks";
                    break;
                case "HotMealDAL":
                    table = "HotMeals";
                    break;
                case "PizzaDAL":
                    table = "Pizzas";
                    break;
                case "SaladDAL":
                    table = "Salads";
                    break;
                case "SoupDAL":
                    table = "Soups";
                    break;
            }
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                var properties = typeof(T).GetProperties();
                int propCount = 0;
                SqlCommand command = new SqlCommand
                {
                    CommandType = CommandType.Text,
                    Connection = connection
                };

                var query = $"insert into {table} values (";
                foreach (var prop in properties)
                {
                    if (prop.Name != "Id")
                    {
                        propCount++;
                        command.Parameters.AddWithValue($"@{prop.Name}", prop.GetValue(product));
                        query += $"@{prop.Name} ,";
                    }
                }
                query = query.Remove(query.Length - 1);
                query += ")";
                command.CommandText = query;

                connection.Open();
                try 
                {
                    var added = command.ExecuteNonQuery();
                    if (added == 0)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
                catch
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// Update product by id
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="product">product</param>
        /// <returns>true if successfully updated</returns>
        public bool UpdateProduct<T>(T product)
        {
            var properties = typeof(T).GetProperties();
            string table = null;
            switch (typeof(T).Name.ToString())
            {
                case "BurgerDAL":
                    table = "Burgers";
                    break;
                case "AlcoholDrinkDAL":
                    table = "AlcoholDrinks";
                    break;
                case "DrinkDAL":
                    table = "Drinks";
                    break;
                case "HotMealDAL":
                    table = "HotMeals";
                    break;
                case "PizzaDAL":
                    table = "Pizzas";
                    break;
                case "SaladDAL":
                    table = "Salads";
                    break;
                case "SoupDAL":
                    table = "Soups";
                    break;
            }
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand
                {
                    CommandType = CommandType.Text,
                    Connection = connection
                };

                string query = $"update {table} set ";
                foreach (var prop in properties)
                {
                    if (prop.Name != "Id")
                    {
                        command.Parameters.AddWithValue($"@{prop.Name}", prop.GetValue(product));
                        query += $"{prop.Name} = @{prop.Name} ,";
                    }
                }
                query = query.Remove(query.Length - 1);
                query += $"where Id = {typeof(T).GetProperty("Id").GetValue(product)}";
                command.CommandText = query;
                
                connection.Open();
                
                var updated = command.ExecuteNonQuery();
                if (updated == 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }







        /// <summary>
        /// Delete product
        /// </summary>
        /// <param name="product">product</param>
        /// <returns>true if successfully deleted</returns>
        public bool DeleteProduct<T>(T product)
        {
            string table = null;
            switch (typeof(T).Name.ToString())
            {
                case "BurgerDAL":
                    table = "Burgers";
                    break;
                case "AlcoholDrinkDAL":
                    table = "AlcoholDrinks";
                    break;
                case "DrinkDAL":
                    table = "Drinks";
                    break;
                case "HotMealDAL":
                    table = "HotMeals";
                    break;
                case "PizzaDAL":
                    table = "Pizzas";
                    break;
                case "SaladDAL":
                    table = "Salads";
                    break;
                case "SoupDAL":
                    table = "Soups";
                    break;
            }

            using (var connection = new SqlConnection(connectionString))
            {
                var command = new SqlCommand
                {
                    CommandType = CommandType.Text,
                    CommandText = $"Delete From {table} Where Id = @id",
                    Connection = connection
                };

                command.Parameters.AddWithValue("@id", product.GetType().GetProperty("Id").GetValue(product));
                
                connection.Open();
                var deleted = command.ExecuteNonQuery();
                if (deleted == 0)
                {
                    return false;
                }
               
                return true;
            }
        }

    }
}

