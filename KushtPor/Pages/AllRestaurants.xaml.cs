using System.Windows.Controls;

namespace KushtPor.Pages
{
    /// <summary>
    /// Interaction logic for AllRestaurants.xaml
    /// </summary>
    public partial class AllRestaurants : Page
    {
        public string username, accessToken;

        public AllRestaurants(string username, string accessToken)
        {
            this.username = username;

            this.accessToken = accessToken;
            InitializeComponent();
            this.menu.OnNavigateParentReady += MyControl_OnNavigateParentReady;
        }

        // username its not that username need to correct
        private void MyControl_OnNavigateParentReady(string name)
        {
            switch (name)
            {
                case "AlcoholDrinks":
                    secondFrame.Navigate(new Pages.AlcoholDrinks(accessToken, username));
                    break;

                case "Burgers":
                    secondFrame.Navigate(new Pages.Burgers(accessToken, username));
                    break;

                case "Drinks":
                    secondFrame.Navigate(new Pages.Drinks(accessToken, username));
                    break;

                case "HotMeals":
                    secondFrame.Navigate(new Pages.HotMeals(accessToken, username));
                    break;

                case "Pizzas":
                    secondFrame.Navigate(new Pages.Pizzas(accessToken, username));
                    break;

                case "Salads":
                    secondFrame.Navigate(new Pages.Salads(accessToken, username));
                    break;

                case "Soups":
                    secondFrame.Navigate(new Pages.Soups(accessToken, username));
                    break;
            }
        }
    }
}
