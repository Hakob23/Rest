using System.Windows;
using System.Windows.Controls;

namespace KushtPor.Control
{
    /// <summary>
    /// Interaction logic for SideMenuWithoutTopButtons.xaml
    /// </summary>
    public partial class SideMenuWithoutTopButtons : UserControl
    {
        public delegate void MyEventHandler(string name);

        public event MyEventHandler OnNavigateParentReady2;

        public SideMenuWithoutTopButtons()
        {
            InitializeComponent();
        }

        private void AlcoholDrinks_Click(object sender, RoutedEventArgs e)
        {
            OnNavigateParentReady2("AlcoholDrinksForUser");
        }

        private void Burgers_Click(object sender, RoutedEventArgs e)
        {
            OnNavigateParentReady2("BurgersForUser");
        }

        private void Drinks_Click(object sender, RoutedEventArgs e)
        {
            OnNavigateParentReady2("DrinksForUser");
        }

        private void HotMeals_Click(object sender, RoutedEventArgs e)
        {
            OnNavigateParentReady2("HotMealsForUser");
        }

        private void Pizzas_Click(object sender, RoutedEventArgs e)
        {
            OnNavigateParentReady2("PizzasForUser");
        }

        private void Salads_Click(object sender, RoutedEventArgs e)
        {
            OnNavigateParentReady2("SaladsForUser");
        }

        private void Soups_Click(object sender, RoutedEventArgs e)
        {
            OnNavigateParentReady2("SoupsForUser");
        }
    }
}
