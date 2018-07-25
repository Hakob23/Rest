using KushtPor.ViewModels;
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

namespace KushtPor.Pages
{
    /// <summary>
    /// Interaction logic for Pizzas.xaml
    /// </summary>
    public partial class Pizzas : Page
    {
        private PizzaViewModel pvm;

        public Pizzas(string accessToken, string name)
        {
            InitializeComponent();
            pvm = new PizzaViewModel(name, accessToken);
            List.ItemsSource = pvm.Pizzas;
            this.DataContext = pvm;
        }
    }
}
