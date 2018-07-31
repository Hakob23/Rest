using KushtPor.Commands;
using KushtPor.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace KushtPor.ViewModels
{
    /// <summary>
    /// Tables view model
    /// </summary>
    public class RestTableViewModel
    {
        // List from where gets data
        public ObservableCollection<RestTable> Tables { get; set; }

        //Deleted Item
        public RestTable RestTableDeletedItem { get; set; }

       
        //tables count
        private int tableCount;

        // access Token
        public string accessToken;

        // username
        public string username;

        // http client
        private HttpClient client;

        /// <summary>
        /// Restaurant Name
        /// </summary>
        public string RestaurantName { get; set; }

        /// <summary>
        /// Table ID
        /// </summary>
        public int ID { get; set; }


        /// <summary>
        /// Delete button command
        /// </summary>
        public RelayCommand Delete { get; set; }

        /// <summary>
        /// Add button command
        /// </summary>
        public RelayCommand Add { get; set; }

        /// <summary>
        /// RestTable view model constructor
        /// </summary>
        /// <param name="username">username</param>
        /// <param name="accessToken">accessToken</param>
        public RestTableViewModel(string username, string accessToken)
        {
           
            // accessToken
            this.accessToken = accessToken;

            // username
            this.username = username;


            // create http client instance
            client = new HttpClient();

            // initialize base address
            client.BaseAddress = new Uri("http://localhost:5005/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", this.accessToken);

            var response = client.GetAsync($"api/restaurants/{username}").Result;

            // if success
            if (response.IsSuccessStatusCode)
            {
                // init Alchohol Drinks
                Tables = response.Content.ReadAsAsync<ObservableCollection<RestTable>>().Result;
            }

            tableCount = Tables[Tables.Count - 1].Id;

            Add = new RelayCommand(() => AddTableAsync(), o => true);
            Delete = new RelayCommand(() => DeleteTable(), o => true);
        }

        public async System.Threading.Tasks.Task AddTableAsync()
        {



            //var response = await client.PostAsJsonAsync($"api/restaurants/{username}",table);


            var request = new HttpRequestMessage(HttpMethod.Post, $"api/restaurants/{username}");
            request.Content = new StringContent(JsonConvert.SerializeObject(username), Encoding.UTF8, "application/json");
            var response = this.client.SendAsync(request).Result;


            if (response.IsSuccessStatusCode)
            {
                Tables.Add(new RestTable { RestaurantName = username, Id = ++tableCount});
            }
        }


        public void DeleteTable()
        {
            //deletedTablesNumber.Add(RestTableDeletedItem.Id);
            var request = new HttpRequestMessage(HttpMethod.Delete, $"api/restaurants");
            request.Content = new StringContent(JsonConvert.SerializeObject(RestTableDeletedItem), Encoding.UTF8, "application/json");
            var response = this.client.SendAsync(request).Result;
            Tables.Remove(this.RestTableDeletedItem);
        }
    }
}
