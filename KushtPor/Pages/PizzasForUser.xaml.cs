using KushtPor.ViewModels;
using System.Windows.Controls;

namespace KushtPor.Pages
{
    /// <summary>
    /// Interaction logic for PizzasForUser.xaml
    /// </summary>
    public partial class PizzasForUser : Page
    {
        private string accessToken, restName;

        private int tableId;

        private PizzasForUserViewModel viewModel;

        public PizzasForUser(string accessToken, string restName, int tableId)
        {
            this.accessToken = accessToken;
            this.restName = restName;
            this.tableId = tableId;
            viewModel = new PizzasForUserViewModel(restName, accessToken, tableId);
            InitializeComponent();
            List.ItemsSource = viewModel.Pizzas;
            this.DataContext = viewModel;
        }
    }
}
