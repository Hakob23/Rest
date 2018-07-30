using System.Windows.Controls;

namespace KushtPor.Pages
{
    /// <summary>
    /// Interaction logic for MenuForOrder.xaml
    /// </summary>
    public partial class MenuForOrder : Page
    {
        // username, restaurantName, accessToken
        public string username, restaurantName, accessToken;

        public int tableId;

        public MenuForOrder(string username, string restaurantName, int tableId, string accessToken)
        {
            this.username = username;

            this.restaurantName = restaurantName;

            this.tableId = tableId;

            this.accessToken = accessToken;

            InitializeComponent();
            this.menuWithoutTop.OnNavigateParentReady2 += MyControl_OnNavigateParentReady;
            
        }
        
        private void MyControl_OnNavigateParentReady(string name)
        {
            switch (name)
            {
                case "AlcoholDrinksForUser":
                    secondFrame.Navigate(new Pages.AlcoholDrinksForUser(accessToken, this.restaurantName, tableId));
                    break;

                case "BurgersForUser":
                    secondFrame.Navigate(new Pages.BurgersForUser(accessToken, this.restaurantName, tableId));
                    break;

                case "DrinksForUser":
                    secondFrame.Navigate(new Pages.DrinksForUser(accessToken, this.restaurantName, tableId));
                    break;

                case "HotMealsForUser":
                    secondFrame.Navigate(new Pages.HotMealsForUser(accessToken, this.restaurantName, tableId));
                    break;

                case "PizzasForUser":
                    secondFrame.Navigate(new Pages.PizzasForUser(accessToken, this.restaurantName, tableId));
                    break;

                case "SaladsForUser":
                    secondFrame.Navigate(new Pages.SaladsForUser(accessToken, this.restaurantName, tableId));
                    break;

                case "SoupsForUser":
                    secondFrame.Navigate(new Pages.SoupsForUser(accessToken, this.restaurantName, tableId));
                    break;
            }
        }
    }
}
