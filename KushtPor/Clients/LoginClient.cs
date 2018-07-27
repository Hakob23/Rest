using IdentityModel.Client;

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
        public string LogIn(string username, string password)
        {
            // discovery client
            var disco = DiscoveryClient.GetAsync("http://localhost:5000").Result;

            // getting token client with client id and secret
            try
            {
                var tokenClient = new TokenClient(
                disco.TokenEndpoint,
                "ro.client",
                "secret");

                // token response for username and password
                var tokenResponse = tokenClient.RequestResourceOwnerPasswordAsync(
                    username, password).Result;
                
                // acces token
                this._accessToken = tokenResponse.AccessToken;

                return this._accessToken;
            }
            catch
            {
                return "error";
            }
            

            //this.httpClient.SetBearerToken(this._accessToken);
        }
    }
}
