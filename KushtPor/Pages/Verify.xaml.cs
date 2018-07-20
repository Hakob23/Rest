using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace KushtPor.Pages
{
    /// <summary>
    /// Interaction logic for Verify.xaml
    /// </summary>
    public partial class Verify : Page
    {
        public Verify()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("http://localhost:5002");
            httpClient.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            //var json = JsonConvert.SerializeObject(this.Code.Text);

            // Post async json object
            var verifLink = $"api/verify/{this.Code.Text}";

            var response = httpClient.GetAsync(verifLink).Result;

            this.NavigationService.Navigate(new Pages.SignIn());
        }
    }
}
