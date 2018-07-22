using System;
using System.Collections.Generic;
using System.Linq;
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

namespace KushtPor
{
    /// <summary>
    /// Interaction logic for SideMenuControl.xaml
    /// </summary>
    public partial class SideMenuControl : UserControl
    {
        public delegate void MyEventHandler(string name);

        public event MyEventHandler OnNavigateParentReady;

        public SideMenuControl()
        {
            InitializeComponent();
        }

        private void AlcoholDrinks_Click(object sender, RoutedEventArgs e)
        {
            OnNavigateParentReady("AlcoholDrinks");
        }

        private void Burgers_Click(object sender, RoutedEventArgs e)
        {
            OnNavigateParentReady("Burgers");
        }

        private void Drinks_Click(object sender, RoutedEventArgs e)
        {
            OnNavigateParentReady("Drinks");
        }

        private void HotMeals_Click(object sender, RoutedEventArgs e)
        {
            OnNavigateParentReady("HotMeals");
        }

        private void Pizzas_Click(object sender, RoutedEventArgs e)
        {
            OnNavigateParentReady("Pizzas");
        }

        private void Salads_Click(object sender, RoutedEventArgs e)
        {
            OnNavigateParentReady("Salads");
        }

        private void Soups_Click(object sender, RoutedEventArgs e)
        {
            OnNavigateParentReady("Soups");
        }
    }
}
