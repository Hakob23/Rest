using KushtPor.ViewModels;
using System.Windows.Controls;
using System.Windows.Documents;


namespace KushtPor.Pages
{
    /// <summary>
    /// Interaction logic for Drinks.xaml
    /// </summary>
    public partial class Drinks : Page
    {
        private DrinkViewModel dvm;

        public Drinks(string accessToken, string name)
        {
            InitializeComponent();
            dvm = new DrinkViewModel(name, accessToken);
            List.ItemsSource = dvm.Drinks;
            this.DataContext = dvm;

        }
    }
}
