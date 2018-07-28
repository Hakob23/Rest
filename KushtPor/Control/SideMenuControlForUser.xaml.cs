using KushtPor.ViewModels;
using System.Windows.Controls;

namespace KushtPor.Control
{
    /// <summary>
    /// Interaction logic for SideMenuControlForUser.xaml
    /// </summary>
    public partial class SideMenuControlForUser : UserControl
    {

        public delegate void MyEventHandler(string name);

        public event MyEventHandler OnNavigateParentReady;

        public SideMenuControlForUser()
        {
            InitializeComponent();
            this.DataContext = new SideMenuControlViewModel();
        }

        private void AlcoholDrinks_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            OnNavigateParentReady("AlcoholDrinks");
        }

        private void Burgers_Click(object sender, System.Windows.RoutedEventArgs e)
        {

        }

        private void Drinks_Click(object sender, System.Windows.RoutedEventArgs e)
        {

        }

        private void HotMeals_Click(object sender, System.Windows.RoutedEventArgs e)
        {

        }

        private void Pizzas_Click(object sender, System.Windows.RoutedEventArgs e)
        {

        }

        private void Salads_Click(object sender, System.Windows.RoutedEventArgs e)
        {

        }

        private void Soups_Click(object sender, System.Windows.RoutedEventArgs e)
        {

        }
    }
}
