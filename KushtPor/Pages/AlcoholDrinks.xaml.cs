using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace KushtPor.Pages
{
    /// <summary>
    /// Interaction logic for AlcoholDrinks.xaml
    /// </summary>
    public partial class AlcoholDrinks : Page
    {
        string userName;
        string accessToken;
        public int count;
        HttpClient client;

        public AlcoholDrinks(string accessToken, string name)
        {
            this.userName = name;
            this.accessToken = accessToken;

            CreateAlcoholDrinksMenu();
        }

        private async void CreateAlcoholDrinksMenu()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:5001/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization =
                                new AuthenticationHeaderValue("Bearer", this.accessToken);

            var response = await client.GetAsync($"api/alcoholdrinks/{this.userName}");

            List<AlcoholDrink> products = new List<AlcoholDrink>();

            if (response.IsSuccessStatusCode)
            {
                products = await response.Content.ReadAsAsync<List<AlcoholDrink>>();
            }

            this.count = products.Count;

            for (int i = 0; i < count; i++)
            {
                RowDefinition gridRow1 = new RowDefinition();

                gridRow1.Height = new GridLength(45);

                this.MyGrid.RowDefinitions.Add(gridRow1);
            }

            for (int i = 0; i < count; i++)
            {
                StackPanel stackPanel = new StackPanel
                {
                    Orientation = Orientation.Vertical,
                };

                TextBlock nameBlock = new TextBlock
                {
                    Text = products[i].Name,
                    TextAlignment = TextAlignment.Center,
                    FontSize = 12,
                };

                TextBlock alcoholBlock = new TextBlock
                {
                    Text = products[i].Alcohol.ToString(),
                    TextAlignment = TextAlignment.Center,
                    FontSize = 12,
                };

                TextBlock volumeBlock = new TextBlock
                {
                    Text = products[i].Volume.ToString(),
                    TextAlignment = TextAlignment.Center,
                    FontSize = 12,
                };

                TextBlock priceBlock = new TextBlock
                {
                    Text = products[i].Price.ToString(),
                    TextAlignment = TextAlignment.Center,
                    FontSize = 12,
                };

                stackPanel.Children.Add(nameBlock);
                stackPanel.Children.Add(alcoholBlock);
                stackPanel.Children.Add(volumeBlock);
                stackPanel.Children.Add(priceBlock);

                int rowCount1 = 0;
                int rowCount2 = 0;

                if (i % 2 == 0)
                {
                    Grid.SetColumn(stackPanel, 0);
                    Grid.SetRow(stackPanel, rowCount1);
                    ++rowCount1;
                }
                else
                {
                    Grid.SetColumn(stackPanel, 2);
                    Grid.SetRow(stackPanel, rowCount2);
                    ++rowCount2;
                }
            }
        }
    }
}
