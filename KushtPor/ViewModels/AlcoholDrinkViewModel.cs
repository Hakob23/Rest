using KushtPor.Commands;
using Newtonsoft.Json;
using System;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace KushtPor.ViewModels
{
    /// <summary>
    /// Alcohols view model
    /// </summary>
    class AlcoholDrinkViewModel 
    {
        public AlcoholDrink AlcoholDrinkDeleteItem { get; set; }

        public AlcoholDrink Drink { get; set; }

        // List from where gets data
        public ObservableCollection<AlcoholDrink> Alcohols { get; set; }

        // access Token
        public string accessToken;

        // username
        public string username;

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
        /// Alcohol Add Name
        /// </summary>
        public string AddName { get; set; }

        /// <summary>
        /// Alcohol Add Price
        /// </summary>
        public double AddPrice { get; set; }

        /// <summary>
        /// Add Driks Alcohol Procents;
        /// </summary>
        public double AddAlcohol { get; set; }


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
        /// AlcoholDrink view model constructor
        /// </summary>
        /// <param name="username">username</param>
        /// <param name="accessToken">accessToken</param>
        public AlcoholDrinkViewModel(string username, string accessToken)
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

            Add = new RelayCommand(() => AddAlcoholAsync(), o => true);
            Delete = new RelayCommand(() => DeleteAlcohol(), o => true);
        }

        public async System.Threading.Tasks.Task AddAlcoholAsync()
        {
           
            var alcohol = new AlcoholDrink
            {
                Name = AddName,
                Price = AddPrice,
                Alcohol = AddAlcohol,
                Volume = AddVolume,
                Restaurant = username
            };

            var response = await client.PostAsJsonAsync($"api/alcoholdrinks", alcohol);

            if (response.IsSuccessStatusCode)
            {
                Alcohols.Add(alcohol);
            }
        }

        public void DeleteAlcohol()
        {
            var request = new HttpRequestMessage(HttpMethod.Delete, $"api/alcoholdrinks");
            request.Content = new StringContent(JsonConvert.SerializeObject(AlcoholDrinkDeleteItem), Encoding.UTF8, "application/json");
            var response = this.client.SendAsync(request).Result;
            Alcohols.Remove(this.AlcoholDrinkDeleteItem);
        }


    }
}
