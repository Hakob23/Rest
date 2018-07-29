using KushtPor.Commands;
using Newtonsoft.Json;
using System;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace KushtPor.ViewModels
{
    class HotMealViewModel 
    {
        public HotMeal HotMealsDeleteItem { get; set; }

        // List from where gets data
        public ObservableCollection<HotMeal> Meals { get; set; }

        // access Token
        public string accessToken;

        // username
        public string username;

        // http client
        private HttpClient client;

        ///// <summary>
        ///// HotMeal Id
        ///// </summary>
        public int Id { get; set; }

        ///// <summary>
        ///// HotMeal Name
        ///// </summary>
        public string Name { get; set; }

        ///// <summary>
        ///// HotMeal Price
        ///// </summary>
        public double Price { get; set; }

        ///// <summary>
        ///// HotMeal Content
        ///// </summary>
        public string Content { get; set; }

        /// <summary>
        /// HotMeal Add Name
        /// </summary>
        public string AddName { get; set; }

        /// <summary>
        /// HotMeal Add Price
        /// </summary>
        public double AddPrice { get; set; }

        /// <summary>
        /// HotMeal Add Content
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
        /// HotMeal view model constructor
        /// </summary>
        /// <param name="username">username</param>
        /// <param name="accessToken">accessToken</param>
        public HotMealViewModel(string username, string accessToken)
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
            var response = client.GetAsync($"api/hotmeals/{username}").Result;

            // if success
            if (response.IsSuccessStatusCode)
            {
                // init Hot Meals
               Meals = response.Content.ReadAsAsync<ObservableCollection<HotMeal>>().Result;
            }

            Add = new RelayCommand(() => AddHotMealAsync(), o => true);
            Delete = new RelayCommand(() => DeleteHotMealAsync(), o => true);
        }

        public async System.Threading.Tasks.Task AddHotMealAsync()
        {
            var meals = new HotMeal
            {
                Name = AddName,
                Price = AddPrice,
                Content = AddContent,
                Restaurant = username
            };

            var response = await client.PostAsJsonAsync($"api/hotmeals", meals);

            if (response.IsSuccessStatusCode)
            {
                Meals.Add(meals);
            }
        }

        public void DeleteHotMealAsync()
        {
            var request = new HttpRequestMessage(HttpMethod.Delete, $"api/hotmeals");
            request.Content = new StringContent(JsonConvert.SerializeObject(HotMealsDeleteItem), Encoding.UTF8, "application/json");
            var response = this.client.SendAsync(request).Result;
            Meals.Remove(this.HotMealsDeleteItem);
        }
    }
}
