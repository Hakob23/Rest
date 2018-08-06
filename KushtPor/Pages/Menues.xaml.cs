using System.Windows.Controls;


namespace KushtPor.Pages
{
    /// <summary>
    /// Interaction logic for Menues.xaml
    /// </summary>
    public partial class Menues : Page
    {
        string userName;
        string accesToken;


        public Menues()
        {
            InitializeComponent();

        }

        public Menues(string accesToken, string userName)
        {
            this.userName = userName;
            this.accesToken = accesToken;

            InitializeComponent();
            this.menu.OnNavigateParentReady += MyControl_OnNavigateParentReady;
            //secondFrame.Navigate(new Pages.Login());
        }

        private void MyControl_OnNavigateParentReady(string name)
        {
            switch (name)
            {
                case "AlcoholDrinks":
                    secondFrame.Navigate(new Pages.AlcoholDrinks(accesToken, userName));
                    break;

                case "Burgers":
                    secondFrame.Navigate(new Pages.Burgers(accesToken, userName));
                    break;

                case "Drinks":
                    secondFrame.Navigate(new Pages.Drinks(accesToken, userName));
                    break;

                case "HotMeals":
                    secondFrame.Navigate(new Pages.HotMeals(accesToken, userName));
                    break;

                case "Pizzas":
                    secondFrame.Navigate(new Pages.Pizzas(accesToken, userName));
                    break;

                case "Salads":
                    secondFrame.Navigate(new Pages.Salads(accesToken, userName));
                    break;

                case "Soups":
                    secondFrame.Navigate(new Pages.Soups(accesToken, userName));
                    break;
                case "Table":
                    this.NavigationService.Navigate(new Pages.Tables(accesToken, userName));
                    break;
            }
        }
    }
}
