using KushtPor.ViewModels;
using System.Windows.Controls;

namespace KushtPor.Pages
{
    /// <summary>
    /// Interaction logic for Tables.xaml
    /// </summary>
    public partial class Tables : Page
    {
        public string accessToken;
        public string username;
        private TablesViewModel viewModel;

        public Tables(string accessToken, string username)
        {
            this.accessToken = accessToken;
            this.username = username;
            viewModel = new TablesViewModel(accessToken, username);
            InitializeComponent();
            this.DataContext = viewModel;
            this.Orders.Navigate += MyControl_OnNavigateParentReady;
        }

        private void MyControl_OnNavigateParentReady(string name)
        {
            switch (name)
            {
                case "Menues":
                    this.NavigationService.Navigate(new Pages.Menues(accessToken, username));
                    break;
            }
        }

    }
}
