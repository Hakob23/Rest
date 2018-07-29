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
        private void MyControl_OnNavigateParentReady(string name, string restName)
        {
            switch (name)
            {
                case "AlcoholDrinksForUser":
                    secondFrame.Navigate(new Pages.AlcoholDrinksForUser(accessToken, restName, 0));
                    break;

                case "BurgersForUser":
                    secondFrame.Navigate(new Pages.Burgers(accessToken, restName));
                    break;

                case "DrinksForUser":
                    secondFrame.Navigate(new Pages.Drinks(accessToken, restName));
                    break;

                case "HotMealsForUser":
                    secondFrame.Navigate(new Pages.HotMeals(accessToken, restName));
                    break;

                case "PizzasForUser":
                    secondFrame.Navigate(new Pages.Pizzas(accessToken, restName));
                    break;

                case "SaladsForUser":
                    secondFrame.Navigate(new Pages.Salads(accessToken, restName));
                    break;

                case "SoupsForUser":
                    secondFrame.Navigate(new Pages.Soups(accessToken, restName));
                    break;
            }
        }
    }
}
