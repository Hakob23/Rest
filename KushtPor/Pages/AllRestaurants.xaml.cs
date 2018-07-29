using System.Windows.Controls;

namespace KushtPor.Pages
{
    /// <summary>
    /// Interaction logic for AllRestaurants.xaml
    /// </summary>
    public partial class AllRestaurants : Page
    {
        private string username, accessToken;

        private int tableId;

        public AllRestaurants(string username, string accessToken, int tableId)
        {
            this.username = username;
            this.tableId = tableId;
            this.accessToken = accessToken;

            InitializeComponent();
            this.menu.OnNavigateParentReady += MyControl_OnNavigateParentReady;
        }
        
        private void MyControl_OnNavigateParentReady(string name, string restName)
        {
            switch (name)
            {
                case "AlcoholDrinksForUser":
                    secondFrame.Navigate(new Pages.AlcoholDrinksForUser(accessToken, restName, tableId));
                    break;

                case "BurgersForUser":
                    secondFrame.Navigate(new Pages.BurgersForUser(accessToken, restName, tableId));
                    break;

                case "DrinksForUser":
                    secondFrame.Navigate(new Pages.DrinksForUser(accessToken, restName, tableId));
                    break;

                case "HotMealsForUser":
                    secondFrame.Navigate(new Pages.HotMealsForUser(accessToken, restName, tableId));
                    break;

                case "PizzasForUser":
                    secondFrame.Navigate(new Pages.PizzasForUser(accessToken, restName, tableId));
                    break;

                case "SaladsForUser":
                    secondFrame.Navigate(new Pages.SaladsForUser(accessToken, restName, tableId));
                    break;

                case "SoupsForUser":
                    secondFrame.Navigate(new Pages.SoupsForUser(accessToken, restName, tableId));
                    break;
            }
        }
    }
}
