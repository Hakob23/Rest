using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;

namespace KushtPor.ViewModels
{
    class PizzaViewModel
    {
        public List<Pizza> Pizzas;
        public string accessToken;
        public string username;
        private HttpClient client;

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
            Pizzas = new List<Pizza>();

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
               Pizzas = response.Content.ReadAsAsync<List<Pizza>>().Result;
            }

        }
    }
}
