using KushtPor.Commands;
using KushtPor.Models;
using System;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Net.Http.Headers;

namespace KushtPor.ViewModels
{
    public class HotMealsForUserViewModel
    {
        public delegate void MyEventHandler(Order ord);

        public static event MyEventHandler OrdEventHotMeal;

        public HotMeal HotMealsOrderItem { get; set; }

        // List from where gets data
        public ObservableCollection<HotMeal> Meals { get; set; }

        // access Token
        public string accessToken;

        // username
        public string username;

        // table Id
        public int tableId;

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
        /// Add button command
        /// </summary>
        public RelayCommand Order { get; set; }

        /// <summary>
        /// MessegeBox
        /// </summary>
        public string Messege { get; set; }
        
        /// <summary>
        /// HotMeal view model constructor
        /// </summary>
        /// <param name="username">username</param>
        /// <param name="accessToken">accessToken</param>
        public HotMealsForUserViewModel(string username, string accessToken, int tableId)
        {
            // accessToken
            this.accessToken = accessToken;

            // username
            this.username = username;

            //tableId
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
            var response = client.GetAsync($"api/hotmeals/{username}").Result;

            // if success
            if (response.IsSuccessStatusCode)
            {
                // init Hot Meals
                Meals = response.Content.ReadAsAsync<ObservableCollection<HotMeal>>().Result;
            }

            Order = new RelayCommand(() => OrderHotMealAsync(), o => true);
        }

        public async System.Threading.Tasks.Task OrderHotMealAsync()
        {
            var ord = new Order();
            ord.TableId = this.tableId;
            ord.OrderCategory = "Hot Meal";
            ord.Quantity = 1;
            ord.Restaurant = this.username;
            ord.MealId = HotMealsOrderItem.Id;
            ord.Messege = this.Messege;
            OrdEventHotMeal(ord);
        }
    }
}
