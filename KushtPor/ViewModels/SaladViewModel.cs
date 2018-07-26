using KushtPor.Commands;
using System;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Net.Http.Headers;

namespace KushtPor.ViewModels
{
    /// <summary>
    /// Salad View model
    /// </summary>
    class SaladViewModel : ViewModel
    {
        // List from where gets data
        public ObservableCollection<Salad> Salads { get; set; }

        // access Token
        public string accessToken;

        // username
        public string username;

        // http client
        private HttpClient client;

        /// <summary>
        /// Salad Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Salad Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Salad Price
        /// </summary>
        public double Price { get; set; }

        ///// <summary>
        ///// Salad Content
        ///// </summary>
        public string Content { get; set; }

        /// <summary>
        /// Salad Id
        /// </summary>
        public int AddID { get; set; }

        /// <summary>
        /// Salad Add Name
        /// </summary>
        public string AddName { get; set; }

        /// <summary>
        /// Salad Add Price
        /// </summary>
        public double AddPrice { get; set; }

        /// <summary>
        /// Salad Add Content
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
        /// Salad view model constructor
        /// </summary>
        /// <param name="username">username</param>
        /// <param name="accessToken">accessToken</param>
        public SaladViewModel(string username, string accessToken)
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
            var response = client.GetAsync($"api/salads/{username}").Result;

            // if success
            if (response.IsSuccessStatusCode)
            {
                // init Salads
                Salads = response.Content.ReadAsAsync<ObservableCollection<Salad>>().Result;
            }

            Add = new RelayCommand(() => AddSaladAsync(), o => true);
            Delete = new RelayCommand(() => DeleteSalad(), o => true);


        }

        public async System.Threading.Tasks.Task AddSaladAsync()
        {
            var salad = new Salad
            {
                Name = AddName,
                Price = AddPrice,
                Content = AddContent,
                Restaurant = username
            };

            var response = await client.PostAsJsonAsync($"api/salads", salad);

            if (response.IsSuccessStatusCode)
            {
                Salads.Add(salad);
            }
        }

        public void DeleteSalad()
        {
            var response = client.GetAsync($"api/salads/{username}/{AddID}").Result;

            Salads.Remove(response.Content.ReadAsAsync<Salad>().Result);

            response = client.DeleteAsync($"api/salads/{username}/{AddID}").Result;

        }
    }
}
