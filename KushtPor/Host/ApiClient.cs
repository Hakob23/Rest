using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace KushtPor
{
    public class ApiClient
    {
        /// <summary>
        /// Access token
        /// </summary>
        private string accessToken;

        /// <summary>
        /// Http client
        /// </summary>
        private HttpClient httpClient;

        public ApiClient()
        {
            this.httpClient = new HttpClient();
            this.httpClient.BaseAddress = new Uri("http://localhost:5002");
            this.httpClient.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public HttpResponseMessage RegisterUser(User user)
        {
            var json = JsonConvert.SerializeObject(user);

            var response = this.httpClient.PostAsync("api/registration",
                new StringContent(json, Encoding.UTF8, "application/json")).Result;

            return response;
        }
    }
}
