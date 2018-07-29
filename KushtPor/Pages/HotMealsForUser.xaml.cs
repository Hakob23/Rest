using KushtPor.ViewModels;
using System.Windows.Controls;

namespace KushtPor.Pages
{
    /// <summary>
    /// Interaction logic for HotMealsForUser.xaml
    /// </summary>
    public partial class HotMealsForUser : Page
    {
        private string accessToken, restName;

        private int tableId;

        private HotMealsForUserViewModel viewModel;

        public HotMealsForUser(string accessToken, string restName, int tableId)
        {
            this.accessToken = accessToken;
            this.restName = restName;
            this.tableId = tableId;
            viewModel = new HotMealsForUserViewModel(restName, accessToken, tableId);
            InitializeComponent();
            List.ItemsSource = viewModel.Meals;
            this.DataContext = viewModel;
        }
    }
}
