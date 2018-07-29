using KushtPor.Commands;
using System;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Net.Http.Headers;

namespace KushtPor.ViewModels
{
    public class AlcoholDrinkForUserViewModel
    {
        public AlcoholDrink AlcoholDrinkOrderItem { get; set; }

        public AlcoholDrink Drink { get; set; }

        // List from where gets data
        public ObservableCollection<AlcoholDrink> Alcohols { get; set; }

        // access Token
        public string accessToken;

        // username
        public string username;

        // tableId
        public int tableId;

        // http client
        private HttpClient client;

        /// <summary>
        /// Alcohol Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Alcohol Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Alcohol Price
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
        /// Add button command
        /// </summary>
        public RelayCommand Order { get; set; }

        /// <summary>
        /// Messege
        /// </summary>
        public string Messege { get; set; }

        /// <summary>
        /// AlcoholDrink view model constructor
        /// </summary>
        /// <param name="username">username</param>
        /// <param name="accessToken">accessToken</param>
        public AlcoholDrinkForUserViewModel(string username, string accessToken, int tableId)
        {
            // accessToken
            this.accessToken = accessToken;

            // username
            this.username = username;

            // create http client instance
            client = new HttpClient();

            // initialize base address
            client.BaseAddress = new Uri("http://localhost:5001/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", this.accessToken);

            // get response
            var response = client.GetAsync($"api/alcoholdrinks/{username}").Result;

            // if success
            if (response.IsSuccessStatusCode)
            {
                // init Alchohol Drinks
                Alcohols = response.Content.ReadAsAsync<ObservableCollection<AlcoholDrink>>().Result;
            }

            Order = new RelayCommand(() => AddOrderAsync(), o => true);
           
        }

        public async System.Threading.Tasks.Task AddOrderAsync()
        {
            
        }
        
    }
}
