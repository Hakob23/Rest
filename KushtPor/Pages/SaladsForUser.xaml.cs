using KushtPor.ViewModels;
using System.Windows.Controls;

namespace KushtPor.Pages
{
    /// <summary>
    /// Interaction logic for SaladsForUser.xaml
    /// </summary>
    public partial class SaladsForUser : Page
    {
        private string accessToken, restName;

        private int tableId;

        private SaladsForUserViewModel viewModel;

        public SaladsForUser(string accessToken, string restName, int tableId)
        {
            this.accessToken = accessToken;
            this.restName = restName;
            this.tableId = tableId;
            viewModel = new SaladsForUserViewModel(restName, accessToken, tableId);
            InitializeComponent();
            List.ItemsSource = viewModel.Salads;
            this.DataContext = viewModel;
        }
    }
}
