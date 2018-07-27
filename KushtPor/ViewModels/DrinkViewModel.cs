using KushtPor.Commands;
using System;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Net.Http.Headers;

namespace KushtPor.ViewModels
{
    class DrinkViewModel 
    {
        // List from where gets data
        public ObservableCollection<Drink> Drinks { get; set; }

        // access Token
        public string accessToken;

        // username
        public string username;

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
        /// Delete button command
        /// </summary>
        public RelayCommand Delete { get; set; }

        /// <summary>
        /// Add button command
        /// </summary>
        public RelayCommand Add { get; set; }

        /// <summary>
        /// Drink view model constructor
        /// </summary>
        /// <param name="username">username</param>
        /// <param name="accessToken">accessToken</param>
        public DrinkViewModel(string username, string accessToken)
        {
            // accessToken
            this.accessToken = accessToken;

            // username
            this.username = username;

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

            Add = new RelayCommand(() => AddDrinkAsync(), o => true);
        }

        public async System.Threading.Tasks.Task AddDrinkAsync()
        {
            var drink = new Drink
            {
                Name = AddName,
                Price = AddPrice,
                Volume = AddVolume,
                Restaurant = username
            };

            var response = await client.PostAsJsonAsync($"api/drinks", drink);

            if (response.IsSuccessStatusCode)
            {
                Drinks.Add(drink);
            }
        }
    }
}
