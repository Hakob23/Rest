using KushtPor.Models;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Windows;
using System.Windows.Controls;

namespace KushtPor.Pages
{
    /// <summary>
    /// Interaction logic for EnterId.xaml
    /// </summary>
    public partial class EnterId : Page
    {
        public string username;
        
        public string accessToken;

        public EnterId(string username, string accessToken)
        {
            this.username = username;

            this.accessToken = accessToken;

            InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            // create http client instance
            var client = new HttpClient();

            // initialize base address
            client.BaseAddress = new Uri("http://localhost:5005/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", this.accessToken);

            // get response
            var response = await client.GetAsync($"api/restaurants/{Id.Text}");

            if (response.IsSuccessStatusCode)
            {
                var restaurantName = await response.Content.ReadAsAsync<RestTable>();
                this.NavigationService.Navigate(new MenuForOrder(username, restaurantName.restaurantName, restaurantName.Id, accessToken));
            }
            else
            {
                Id.Text = "";
            }
        }
    }
}
