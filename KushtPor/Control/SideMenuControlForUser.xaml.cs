using KushtPor.ViewModels;
using System.Windows.Controls;

namespace KushtPor.Control
{
    /// <summary>
    /// Interaction logic for SideMenuControlForUser.xaml
    /// </summary>
    public partial class SideMenuControlForUser : UserControl
    {

        public delegate void MyEventHandler(string name, string restName);

        public event MyEventHandler OnNavigateParentReady;

        private SideMenuControlViewModel viewModel;

        public SideMenuControlForUser()
        {
            InitializeComponent();
            viewModel = new SideMenuControlViewModel();
            this.DataContext = viewModel;
        }

        public SideMenuControlForUser(string restName)
        {
            InitializeComponent();
            viewModel = new SideMenuControlViewModel(restName);
            this.DataContext = viewModel;
        }

        private void AlcoholDrinks_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            OnNavigateParentReady("AlcoholDrinksForUser", viewModel.Selected.UserName);
        }

        private void Burgers_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            OnNavigateParentReady("BurgersForUser", viewModel.Selected.UserName);
        }

        private void Drinks_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            OnNavigateParentReady("DrinksForUser", viewModel.Selected.UserName);
        }

        private void HotMeals_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            OnNavigateParentReady("HotMealsForUser", viewModel.Selected.UserName);
        }

        private void Pizzas_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            OnNavigateParentReady("PizzasForUser", viewModel.Selected.UserName);
        }

        private void Salads_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            OnNavigateParentReady("SaladsForUser", viewModel.Selected.UserName);
        }

        private void Soups_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            OnNavigateParentReady("SoupsForUser", viewModel.Selected.UserName);
        }
    }
}
