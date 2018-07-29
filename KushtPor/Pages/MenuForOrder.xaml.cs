using System.Windows.Controls;

namespace KushtPor.Pages
{
    /// <summary>
    /// Interaction logic for MenuForOrder.xaml
    /// </summary>
    public partial class MenuForOrder : Page
    {
        // username, restaurantName, accessToken
        public string username, restaurantName, accessToken;

        public int tableId;

        public MenuForOrder(string username, string restaurantName, int tableId, string accessToken)
        {
            this.username = username;

            this.restaurantName = restaurantName;

            this.tableId = tableId;

            this.accessToken = accessToken;

            InitializeComponent();
        }
    }
}
