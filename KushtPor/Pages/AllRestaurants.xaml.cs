using System.Windows.Controls;

namespace KushtPor.Pages
{
    /// <summary>
    /// Interaction logic for AllRestaurants.xaml
    /// </summary>
    public partial class AllRestaurants : Page
    {
        public string username, accessToken;

        public AllRestaurants(string username, string accessToken)
        {
            this.username = username;

            this.accessToken = accessToken;

            InitializeComponent();
        }
    }
}
