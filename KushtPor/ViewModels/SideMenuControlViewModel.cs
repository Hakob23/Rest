using KushtPor.Models;
using System;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Net.Http.Headers;

namespace KushtPor.ViewModels
{
    public class SideMenuControlViewModel
    {
        public ObservableCollection<RestName> ComboBoxItems { get; set; }

        public RestName Selected { get; set; } = new RestName();

        public SideMenuControlViewModel()
        {
            // create http client instance
            var client = new HttpClient();

            // initialize base address
            client.BaseAddress = new Uri("http://localhost:5002/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            // get response
            var response = client.GetAsync($"api/registration").Result;

            // if success
            if (response.IsSuccessStatusCode)
            {
                // initialize
                ComboBoxItems = response.Content.ReadAsAsync<ObservableCollection<RestName>>().Result;
            }
        }

        public SideMenuControlViewModel(string restName)
        {
            var rest = new RestName();
            rest.UserName = restName;
            ComboBoxItems.Clear();
            ComboBoxItems.Add(rest);
        }
    }
}
