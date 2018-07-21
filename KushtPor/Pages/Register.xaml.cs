using KushtPor.Clients;
using System.Windows;
using System.Windows.Controls;

namespace KushtPor.Pages
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Page
    {
        // user for register
        private User user;
        private RegistrationClient apiClient;
        
        public Login()
        {
            InitializeComponent();
            apiClient = new RegistrationClient();
        }
        
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Pages.SignIn());
        }

        private void Button_Next(object sender, RoutedEventArgs e)
        {
            user = new User();
            user.UserName = this.UserName.Text;
            user.Email = this.EmailName.Text;
            user.Password = this.PassName.Text;
            user.Role = "restaurant";
            var httpResponse = apiClient.RegisterUser(user);

            this.NavigationService.Navigate(new Pages.Verify());
        }
    }
}
