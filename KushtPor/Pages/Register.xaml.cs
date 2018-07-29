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
            if (Checkbox.IsChecked == true)
            {
                user.Role = "restaurant";
            }
            else
            {
                user.Role = "user";
            }
            var httpResponse = apiClient.RegisterUser(user);
            if (httpResponse.IsSuccessStatusCode)
            {
                this.NavigationService.Navigate(new Pages.Verify());
            }
            else
            {
                MessageBox.Show("User with same username is already registered or user with sam email is already registered.", "Wrong Input", MessageBoxButton.OK);
                UserName.Text = "";
                EmailName.Text = "";
                PassName.Password = "";
            }
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
