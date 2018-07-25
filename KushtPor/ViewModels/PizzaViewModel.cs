using KushtPor.Commands;
using System;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Net.Http.Headers;

namespace KushtPor.ViewModels
{
    /// <summary>
    /// Pizzas view model
    /// </summary>
    class PizzaViewModel:ViewModel
    {
        // List from where gets data
        public ObservableCollection<Pizza> Pizzas { get; set; }
        
        // access Token
        public string accessToken;

        // username
        public string username;

        // http client
        private HttpClient client;

        /// <summary>
        /// Pizza Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Pizza Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Pizza Price
        /// </summary>
        public double Price { get; set; }

        /// <summary>
        /// Pizzas Content
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// Pizzas Diametr
        /// </summary>
        public int Diametr { get; set; }

        /// <summary>
        /// Pizza Add Name
        /// </summary>
        public string AddName { get; set; }

        /// <summary>
        /// Pizza Add Price
        /// </summary>
        public double AddPrice { get; set; }

        /// <summary>
        /// Pizzas Add Content
        /// </summary>
        public string AddContent { get; set; }

        /// <summary>
        /// Pizzas Add Diametr
        /// </summary>
        public int AddDiametr { get; set; }



        /// <summary>
        /// Delete button command
        /// </summary>
        public RelayCommand Delete { get; set; }

        /// <summary>
        /// Add button command
        /// </summary>
        public RelayCommand Add { get; set; }

        /// <summary>
        /// Pizza view model constructor
        /// </summary>
        /// <param name="username">username</param>
        /// <param name="accessToken">accessToken</param>
        public PizzaViewModel(string username, string accessToken)
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
            var response = client.GetAsync($"api/pizzas/{username}").Result;
            
            // if success
            if (response.IsSuccessStatusCode)
            {
               // init Piizas
               Pizzas = response.Content.ReadAsAsync<ObservableCollection<Pizza>>().Result;
            }

            Delete = new RelayCommand(() => DeletePizza(), o => true);
            Add = new RelayCommand(() => AddPizzaAsync(), o => true);
        }

        public async System.Threading.Tasks.Task AddPizzaAsync()
        {
            var pizza = new Pizza();
            pizza.Name = AddName;
            pizza.Price = AddPrice;
            pizza.Content = AddContent;
            pizza.Diametr = AddDiametr;
            pizza.Restaurant = username;

            var response = await client.PostAsJsonAsync($"api/pizzas", pizza);

            if (response.IsSuccessStatusCode)
            {
                Pizzas.Add(pizza);
            }
        }

        public void DeletePizza()
        {
            var pizza = new Pizza();
            pizza.Id = Id;
            pizza.Price = Price;
            pizza.Name = Name;
            pizza.Diametr = Diametr;
        }
    }
}
