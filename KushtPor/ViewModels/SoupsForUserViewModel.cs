using KushtPor.Commands;
using KushtPor.Models;
using System;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace KushtPor.ViewModels
{
    public class SoupsForUserViewModel
    {
        public delegate void MyEventHandler(Order ord);

        public static event MyEventHandler OrdEventSoups;

        public Soup SoupsOrderItem { get; set; }

        // List from where gets data
        public ObservableCollection<Soup> Soups { get; set; }

        // access Token
        public string accessToken;

        // username
        public string username;

        // tableId
        public int tableId;

        // http client
        private HttpClient client;

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

        ///// <summary>
        ///// Soup Content
        ///// </summary>
        public string Content { get; set; }

        /// <summary>
        /// Soup Add Name
        /// </summary>
        public string AddName { get; set; }

        /// <summary>
        /// Soup Add Price
        /// </summary>
        public double AddPrice { get; set; }

        /// <summary>
        /// Soup Add Content
        /// </summary>
        public string AddContent { get; set; }

        /// <summary>
        /// Add button command
        /// </summary>
        public RelayCommand Order { get; set; }

        /// <summary>
        /// Messege
        /// </summary>
        public string Messege { get; set; }

        /// <summary>
        /// Soup view model constructor
        /// </summary>
        /// <param name="username">username</param>
        /// <param name="accessToken">accessToken</param>
        public SoupsForUserViewModel(string username, string accessToken, int tableId)
        {
            // accessToken
            this.accessToken = accessToken;

            // username
            this.username = username;

            // tableId
            this.tableId = tableId;

            // create http client instance
            client = new HttpClient();

            // initialize base address
            client.BaseAddress = new Uri("http://localhost:5001/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", this.accessToken);

            // get response
            var response = client.GetAsync($"api/soups/{username}").Result;

            // if success
            if (response.IsSuccessStatusCode)
            {
                // init Soup
                Soups = response.Content.ReadAsAsync<ObservableCollection<Soup>>().Result;
            }

            Order = new RelayCommand(() => OrderSoupAsync(), o => true);
        }

        public async Task OrderSoupAsync()
        {
            var ord = new Order();
            ord.TableId = this.tableId;
            ord.OrderCategory = "Soup";
            ord.Quantity = 1;
            ord.Restaurant = this.username;
            ord.MealId = SoupsOrderItem.Id;
            ord.Messege = this.Messege;
            ord.Price = this.SoupsOrderItem.Price;
            OrdEventSoups(ord);
        }
    }
}
