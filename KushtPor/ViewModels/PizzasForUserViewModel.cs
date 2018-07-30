using KushtPor.Commands;
using KushtPor.Models;
using System;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace KushtPor.ViewModels
{
    public class PizzasForUserViewModel
    {
        public delegate void MyEventHandler(Order ord);

        public static event MyEventHandler OrdEventPizzas;

        public Pizza PizzasOrderItem { get; set; }

        // List from where gets data
        public ObservableCollection<Pizza> Pizzas { get; set; }

        // access Token
        public string accessToken;

        // username
        public string username;

        //tableId
        public int tableId;

        // http client
        private HttpClient client;

        ///// <summary>
        ///// Pizza Id
        ///// </summary>
        public int Id { get; set; }

        ///// <summary>
        ///// Pizza Name
        ///// </summary>
        public string Name { get; set; }

        ///// <summary>
        ///// Pizza Price
        ///// </summary>
        public double Price { get; set; }

        ///// <summary>
        ///// Pizzas Content
        ///// </summary>
        public string Content { get; set; }

        ///// <summary>
        ///// Pizzas Diametr
        ///// </summary>
        public int Diametr { get; set; }

        /// <summary>
        /// Add button command
        /// </summary>
        public RelayCommand Order { get; set; }

        /// <summary>
        /// Messege
        /// </summary>
        public string Messege { get; set; }

        /// <summary>
        /// Pizza view model constructor
        /// </summary>
        /// <param name="username">username</param>
        /// <param name="accessToken">accessToken</param>
        public PizzasForUserViewModel(string username, string accessToken, int tableId)
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
            var response = client.GetAsync($"api/pizzas/{username}").Result;

            // if success
            if (response.IsSuccessStatusCode)
            {
                // init Piizas
                Pizzas = response.Content.ReadAsAsync<ObservableCollection<Pizza>>().Result;
            }
            
            Order = new RelayCommand(() => OrderPizzaAsync(), o => true);
        }

        public async Task OrderPizzaAsync()
        {
            var ord = new Order();
            ord.TableId = this.tableId;
            ord.OrderCategory = "Pizza";
            ord.Quantity = 1;
            ord.Restaurant = this.username;
            ord.MealId = PizzasOrderItem.Id;
            ord.Messege = this.Messege;
            OrdEventPizzas(ord);
        }

    }
}
