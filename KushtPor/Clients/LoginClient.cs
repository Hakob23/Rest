using IdentityModel.Client;
using System;
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
        /// returns access token
        /// </summary>
        /// <param name="username">username</param>
        /// <param name="password">password</param>
        /// <returns></returns>
        public async Task<string> LogIn(string username, string password)
        {
            // discovery client
            var disco = await DiscoveryClient.GetAsync("http://localhost:5000");

            // getting token client with client id and secret
            try
            {
                var res = await GetAccessToken(username, password, disco);

                return res;
            }
            catch
            {
                return "error";
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
