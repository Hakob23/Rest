using KushtPor.ViewModels;
using System.Windows.Controls;

namespace KushtPor.Pages
{
    /// <summary>
    /// Interaction logic for AlcoholDrinksForUser.xaml
    /// </summary>
    public partial class AlcoholDrinksForUser : Page
    {
        public string accessToken, restName;

        public int tableId;

        public AlcoholDrinkForUserViewModel viewModel;

        public AlcoholDrinksForUser(string accessToken, string restName, int tableId)
        {
            this.accessToken = accessToken;
            this.restName = restName;
            this.tableId = tableId;
            viewModel = new AlcoholDrinkForUserViewModel(restName, accessToken, tableId);
            InitializeComponent();
            List.ItemsSource = viewModel.Alcohols;
            this.DataContext = viewModel;
        }
    }
}
