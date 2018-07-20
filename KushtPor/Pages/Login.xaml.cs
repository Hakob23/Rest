using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace KushtPor.Pages
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Page
    {
        private User user;
        private ApiClient apiClient;
        
        public Login()
        {
            InitializeComponent();
            user = new User();
            apiClient = new ApiClient();
        }

        
        
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Pages.SignIn());
        }

        private void Button_Next(object sender, RoutedEventArgs e)
        {
            //user.UserName = this.UserName.Text;
            //user.Email = this.EmailName.Text;
            //user.Password = this.PassName.Text;
            //user.Phone = "1111111";
            //var httpResponse = apiClient.RegisterUser(user);

            //this.NavigationService.Navigate(new Pages.Verify());
            this.NavigationService.Navigate(new Pages.Menues());
        }
    }
}
