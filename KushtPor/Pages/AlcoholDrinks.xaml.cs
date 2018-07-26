using KushtPor.ViewModels;
using System.Windows.Controls;


namespace KushtPor.Pages
{
    /// <summary>
    /// Interaction logic for AlcoholDrinks.xaml
    /// </summary>
    public partial class AlcoholDrinks : Page
    {
        private AlcoholDrinkViewModel advm;

        public AlcoholDrinks(string accessToken, string name)
        {
            InitializeComponent();
            advm = new AlcoholDrinkViewModel(name, accessToken);
            List.ItemsSource = advm.Alcohols;
            this.DataContext = advm;
        }
    }
}
