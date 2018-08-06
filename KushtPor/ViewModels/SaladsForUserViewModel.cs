using KushtPor.Commands;
using KushtPor.Models;
using System;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace KushtPor.ViewModels
{
    public class SaladsForUserViewModel
    {
        public delegate void MyEventHandler(Order ord);

        public static event MyEventHandler OrdEventSalads;

        public Salad SaladOrderItem { get; set; }

        // List from where gets data
        public ObservableCollection<Salad> Salads { get; set; }

        // access Token
        public string accessToken;

        // username
        public string username;

        // tableId
        public int tableId;

        // http client
        private HttpClient client;

        /// <summary>
        /// Salad Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Salad Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Salad Price
        /// </summary>
        public double Price { get; set; }

        ///// <summary>
        ///// Salad Content
        ///// </summary>
        public string Content { get; set; }
        
        /// <summary>
        /// Add button command
        /// </summary>
        public RelayCommand Order { get; set; }

        /// <summary>
        /// Messege
        /// </summary>
        public string Messege { get; set; }

        /// <summary>
        /// Salad view model constructor
        /// </summary>
        /// <param name="username">username</param>
        /// <param name="accessToken">accessToken</param>
        public SaladsForUserViewModel(string username, string accessToken, int tableId)
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
            var response = client.GetAsync($"api/salads/{username}").Result;

            // if success
            if (response.IsSuccessStatusCode)
            {
                // init Salads
                Salads = response.Content.ReadAsAsync<ObservableCollection<Salad>>().Result;
            }

            Order = new RelayCommand(() => OrderSaladAsync(), o => true);
        }

        public async Task OrderSaladAsync()
        {
            var ord = new Order();
            ord.TableId = this.tableId;
            ord.OrderCategory = "Salad";
            ord.Quantity = 1;
            ord.Restaurant = this.username;
            ord.MealId = SaladOrderItem.Id;
            ord.Messege = this.Messege;
            ord.Price = this.SaladOrderItem.Price;
            OrdEventSalads(ord);
        }
    }
}
