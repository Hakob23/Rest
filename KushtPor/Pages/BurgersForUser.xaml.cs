using KushtPor.ViewModels;
using System.Windows.Controls;

namespace KushtPor.Pages
{
    /// <summary>
    /// Interaction logic for BurgersForUser.xaml
    /// </summary>
    public partial class BurgersForUser : Page
    {
        public string accessToken, restName;

        public int tableId;

        public BurgersForUserViewModel viewModel;

        public BurgersForUser(string accessToken, string restName, int tableId)
        {
            this.accessToken = accessToken;
            this.restName = restName;
            this.tableId = tableId;
            viewModel = new BurgersForUserViewModel(restName, accessToken, tableId);
            InitializeComponent();
            List.ItemsSource = viewModel.Burgers;
            this.DataContext = viewModel;
        }
    }
}
