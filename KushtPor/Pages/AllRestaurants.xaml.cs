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
                    secondFrame.Navigate(new Pages.BurgersForUser(accessToken, restName, 0));
                    break;

                case "DrinksForUser":
                    secondFrame.Navigate(new Pages.DrinksForUser(accessToken, restName, 0));
                    break;

                case "HotMealsForUser":
                    secondFrame.Navigate(new Pages.HotMealsForUser(accessToken, restName, 0));
                    break;

                case "PizzasForUser":
                    secondFrame.Navigate(new Pages.PizzasForUser(accessToken, restName, 0));
                    break;

                case "SaladsForUser":
                    secondFrame.Navigate(new Pages.SaladsForUser(accessToken, restName, 0));
                    break;

                case "SoupsForUser":
                    secondFrame.Navigate(new Pages.SoupsForUser(accessToken, restName, 0));
                    break;
            }
        }
    }
}
