using KushtPor.Commands;
using System;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace KushtPor.ViewModels
{
    public class BurgersForUserViewModel
    {
        public Burger BurgerOrderItem { get; set; }

        // List from where gets data
        public ObservableCollection<Burger> Burgers { get; set; }

        // access Token
        public string accessToken;

        // username
        public string username;

        // tableId
        public int tableId;

        // http client
        private HttpClient client;

        /// <summary>
        /// Burger Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Burger Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Burger Price
        /// </summary>
        public double Price { get; set; }

        ///// <summary>
        ///// Burger Content
        ///// </summary>
        public string Content { get; set; }
        
        /// <summary>
        /// Add button command
        /// </summary>
        public RelayCommand Order { get; set; }

        public string Messege { get; set; }

        /// <summary>
        /// Burger view model constructor
        /// </summary>
        /// <param name="username">username</param>
        /// <param name="accessToken">accessToken</param>
        public BurgersForUserViewModel(string username, string accessToken, int tableId)
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
            var response = client.GetAsync($"api/burgers/{username}").Result;

            // if success
            if (response.IsSuccessStatusCode)
            {
                // init Burger
                Burgers = response.Content.ReadAsAsync<ObservableCollection<Burger>>().Result;
            }

            Order = new RelayCommand(() => OrderBurgerAsync(), o => true);
        }

        public async Task OrderBurgerAsync()
        {
        
        }

    }
}
