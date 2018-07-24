using KushtPor.Clients;
using KushtPor.ViewModels;
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
        private RegistrationViewModel regVM;

        public Login()
        {
            InitializeComponent();
            regVM = new RegistrationViewModel(this.NavigationService);
            this.DataContext = regVM;
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
            user.Password = this.PassName.Password;
            user.Role = "restaurant";
            var httpResponse = apiClient.RegisterUser(user);

            this.NavigationService.Navigate(new Pages.Verify());
            //this.NavigationService.Navigate(new Pages.Menues());
        }

        private void Button_PasswordChanged(object sender, RoutedEventArgs e)
        {
            // converting sender to Password box
            var passwordBox = (PasswordBox)sender;

            // setting to view model fields
           this.regVM.Password = passwordBox.Password;

        }
    }
}
