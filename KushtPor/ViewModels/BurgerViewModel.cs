using KushtPor.Commands;
using System;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Net.Http.Headers;

namespace KushtPor.ViewModels
{
    /// <summary>
    /// Burger View model
    /// </summary>
    class BurgerViewModel :ViewModel
    {
        // List from where gets data
        public ObservableCollection<Burger> Burgers { get; set; }

        // access Token
        public string accessToken;

        // username
        public string username;

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
        /// Burger Add Name
        /// </summary>
        public string AddName { get; set; }

        /// <summary>
        /// Burger Add Price
        /// </summary>
        public double AddPrice { get; set; }

        /// <summary>
        /// Burger Add Content
        /// </summary>
        public string AddContent { get; set; }


        /// <summary>
        /// Delete button command
        /// </summary>
        public RelayCommand Delete { get; set; }

        /// <summary>
        /// Add button command
        /// </summary>
        public RelayCommand Add { get; set; }

        /// <summary>
        /// Burger view model constructor
        /// </summary>
        /// <param name="username">username</param>
        /// <param name="accessToken">accessToken</param>
        public BurgerViewModel(string username, string accessToken)
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
            var response = client.GetAsync($"api/burgers/{username}").Result;

            // if success
            if (response.IsSuccessStatusCode)
            {
                // init Burger
                Burgers = response.Content.ReadAsAsync<ObservableCollection<Burger>>().Result;
            }

            Add = new RelayCommand(() => AddBurgerAsync(), o => true);
        }

        public async System.Threading.Tasks.Task AddBurgerAsync()
        {
            var burger = new Burger
            {
                Name = AddName,
                Price = AddPrice,
                Content = AddContent,
                Restaurant = username
            };

            var response = await client.PostAsJsonAsync($"api/burgers", burger);

            if (response.IsSuccessStatusCode)
            {
                Burgers.Add(burger);
            }
        }
    }
}
