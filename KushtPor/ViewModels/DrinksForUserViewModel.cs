using KushtPor.Commands;
using KushtPor.Models;
using System;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace KushtPor.ViewModels
{
    public class DrinksForUserViewModel
    {
        public delegate void MyEventHandler(Order ord);

        public static event MyEventHandler OrdEventDrink;

        public Drink DrinkOrderItem { get; set; }

        // List from where gets data
        public ObservableCollection<Drink> Drinks { get; set; }

        // access Token
        public string accessToken;

        // username
        public string username;

        //tableId
        public int tableId;

        // http client
        private HttpClient client;

        /// <summary>
        /// Drink Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Drink Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Drink Price
        /// </summary>
        public double Price { get; set; }

        /// <summary>
        /// Driks Volume
        /// </summary>
        public double Volume { get; set; }

        /// <summary>
        /// Drink Add Name
        /// </summary>
        public string AddName { get; set; }

        /// <summary>
        /// Drink Add Price
        /// </summary>
        public double AddPrice { get; set; }


        /// <summary>
        /// Add Driks Volume
        /// </summary>
        public double AddVolume { get; set; }
        
        /// <summary>
        /// Add button command
        /// </summary>
        public RelayCommand Order { get; set; }

        /// <summary>
        /// Messege
        /// </summary>
        public string Messege { get; set; }

        /// <summary>
        /// Drink view model constructor
        /// </summary>
        /// <param name="username">username</param>
        /// <param name="accessToken">accessToken</param>
        public DrinksForUserViewModel(string username, string accessToken, int tableId)
        {
            // accessToken
            this.accessToken = accessToken;

            // username
            this.username = username;

            //tableId
            this.tableId = tableId;

            // Pizzas
            //Pizzas = new List<Pizza>();

            // create http client instance
            client = new HttpClient();

            // initialize base address
            client.BaseAddress = new Uri("http://localhost:5001/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", this.accessToken);

            // get response
            var response = client.GetAsync($"api/drinks/{username}").Result;

            // if success
            if (response.IsSuccessStatusCode)
            {
                // init Alchohol Drinks
                Drinks = response.Content.ReadAsAsync<ObservableCollection<Drink>>().Result;
            }

            Order = new RelayCommand(() => AddOrderAsync(), o => true);
        }

        public async Task AddOrderAsync()
        {
            var ord = new Order();
            ord.TableId = this.tableId;
            ord.OrderCategory = "Drink";
            ord.Quantity = 1;
            ord.Restaurant = this.username;
            ord.MealId = DrinkOrderItem.Id;
            ord.Messege = this.Messege;
            ord.Price = this.DrinkOrderItem.Price;
            OrdEventDrink(ord);
        }
        
    }
}
