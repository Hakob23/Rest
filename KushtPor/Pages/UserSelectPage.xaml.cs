using KushtPor.ViewModels;
using System.Windows.Controls;

namespace KushtPor.Pages
{
    /// <summary>
    /// Interaction logic for UserSelectPage.xaml
    /// </summary>
    public partial class UserSelectPage : Page
    {
        public string accessToken, username;

        public UserSelectPageViewModel uspvm; 

        public UserSelectPage(string accessToken, string username)
        {
            this.accessToken = accessToken;
            this.username = username;
            var nav = this.NavigationService;
            InitializeComponent();
            uspvm = new UserSelectPageViewModel(this.NavigationService);
            this.DataContext = uspvm;
        }
    }
}
