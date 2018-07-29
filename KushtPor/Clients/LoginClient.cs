using IdentityModel.Client;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace KushtPor.Clients
{
    class LoginClient
    {
        /// <summary>
        /// Access token
        /// </summary>
        private string _accessToken;

        /// <summary>
        /// Http Client
        /// </summary>
        private HttpClient client;

        /// <summary>
        /// returns access token
        /// </summary>
        /// <param name="username">username</param>
        /// <param name="password">password</param>
        /// <returns></returns>
        public async Task<RoleAndToken> LogIn(string username, string password)
        {
            var result = new RoleAndToken();
            this.client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:5002/");

            // discovery client
            var disco = await DiscoveryClient.GetAsync("http://localhost:5000");

            var response = await client.GetAsync($"api/registration/{username}");

            if(response.IsSuccessStatusCode)
            {
                result.role = response.Content.ReadAsAsync<string>().Result;
            }

            // getting token client with client id and secret
            try
            {
                var res = await GetAccessToken(username, password, disco);
                result.token = res;
                return result;
            }
            catch
            {
                return new RoleAndToken(null, null);
            }
            

            //this.httpClient.SetBearerToken(this._accessToken);
        }

        public async Task<string> GetAccessToken(string username, string password, DiscoveryResponse disco)
        {
            var tokenClient = new TokenClient(
                disco.TokenEndpoint,
                "ro.client",
                "secret");

            // token response for username and password
            var tokenResponse = await tokenClient.RequestResourceOwnerPasswordAsync(
                username, password);

            // acces token
            this._accessToken = tokenResponse.AccessToken;
            return this._accessToken;
        }
    }
}
