using KushtPor.Commands;
using Newtonsoft.Json;
using System;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace KushtPor.ViewModels
{
    /// <summary>
    /// Soup View model
    /// </summary>
    class SoupViewModel
    {
        public Soup SoupsDeleteItem { get; set; }

        // List from where gets data
        public ObservableCollection<Soup> Soups { get; set; }

        // access Token
        public string accessToken;

        // username
        public string username;

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
        /// Delete button command
        /// </summary>
        public RelayCommand Delete { get; set; }

        /// <summary>
        /// Add button command
        /// </summary>
        public RelayCommand Add { get; set; }

        /// <summary>
        /// Soup view model constructor
        /// </summary>
        /// <param name="username">username</param>
        /// <param name="accessToken">accessToken</param>
        public SoupViewModel(string username, string accessToken)
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
            var response = client.GetAsync($"api/soups/{username}").Result;

            // if success
            if (response.IsSuccessStatusCode)
            {
                // init Soup
                Soups = response.Content.ReadAsAsync<ObservableCollection<Soup>>().Result;
            }

            Add = new RelayCommand(() => AddSoupAsync(), o => true);
            Delete = new RelayCommand(() => DeleteSoupAsync(), o => true);
        }

        public async Task AddSoupAsync()
        {
            var soup = new Soup
            {
                Name = AddName,
                Price = AddPrice,
                Content = AddContent,
                Restaurant = username
            };

            var response = await client.PostAsJsonAsync($"api/soups", soup);

            if (response.IsSuccessStatusCode)
            {
                Soups.Add(soup);
            }
        }

        public void DeleteSoupAsync()
        {
            var request = new HttpRequestMessage(HttpMethod.Delete, $"api/soups");
            request.Content = new StringContent(JsonConvert.SerializeObject(SoupsDeleteItem), Encoding.UTF8, "application/json");
            var response = this.client.SendAsync(request).Result;
            Soups.Remove(this.SoupsDeleteItem);
        }
    }
}
