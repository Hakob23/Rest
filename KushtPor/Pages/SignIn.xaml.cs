using KushtPor.Clients;
using System.Windows;
using System.Windows.Controls;

namespace KushtPor.Pages
{
    /// <summary>
    /// Interaction logic for SignIn.xaml
    /// </summary>
    public partial class SignIn : Page
    {
        // client
        private LoginClient client;

        public SignIn()
        {
            InitializeComponent();
            client = new LoginClient();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Pages.Login());
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            // getting accesstoken
            var accesstoken = client.LogIn(this.UserName.Text, this.Pass.Text);
            if (accesstoken != null)
            {
                // navigate to menues page
                this.NavigationService.Navigate(new Pages.Menues(accesstoken, this.UserName.Text));
            }
        }
    }
}
