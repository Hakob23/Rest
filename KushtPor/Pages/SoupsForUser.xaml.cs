using KushtPor.ViewModels;
using System.Windows.Controls;

namespace KushtPor.Pages
{
    /// <summary>
    /// Interaction logic for SoupsForUser.xaml
    /// </summary>
    public partial class SoupsForUser : Page
    {
        private string accessToken, restName;

        private int tableId;

        private SoupsForUserViewModel viewModel;

        public SoupsForUser(string accessToken, string restName, int tableId)
        {
            this.accessToken = accessToken;
            this.restName = restName;
            this.tableId = tableId;
            viewModel = new SoupsForUserViewModel(restName, accessToken, tableId);
            InitializeComponent();
            List.ItemsSource = viewModel.Soups;
            this.DataContext = viewModel;
        }
    }
}
