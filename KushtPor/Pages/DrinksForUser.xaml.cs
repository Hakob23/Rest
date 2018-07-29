using KushtPor.ViewModels;
using System.Windows.Controls;

namespace KushtPor.Pages
{
    /// <summary>
    /// Interaction logic for DrinksForUser.xaml
    /// </summary>
    public partial class DrinksForUser : Page
    {
        private string accessToken, restName;

        private int tableId;

        private DrinksForUserViewModel viewModel; 

        public DrinksForUser(string accessToken, string restName, int tableId)
        {
            this.accessToken = accessToken;
            this.restName = restName;
            this.tableId = tableId;
            viewModel = new DrinksForUserViewModel(restName, accessToken, tableId);
            InitializeComponent();
            List.ItemsSource = viewModel.Drinks;
            this.DataContext = viewModel;
        }
    }
}
