using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using Newtonsoft.Json;

namespace KushtPor.Clients
{
    /// <summary>
    /// Client for registration
    /// </summary>
    public class RegistrationClient
    {
        /// <summary>
        /// Http client
        /// </summary>
        private HttpClient httpClient;

        /// <summary>
        /// Registration client constructor
        /// </summary>
        public RegistrationClient()
        {
            this.httpClient = new HttpClient();
            this.httpClient.BaseAddress = new Uri("http://localhost:5002");
            this.httpClient.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }

        /// <summary>
        /// function to call Registrationapi registration controller
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public HttpResponseMessage RegisterUser(User user)
        {
            // converting to json object
            var json = JsonConvert.SerializeObject(user);

            // Post async json object
            var response = this.httpClient.PostAsync("api/registration",
                new StringContent(json, Encoding.UTF8, "application/json")).Result;

            // get response
            return response;
        }
    }
}
