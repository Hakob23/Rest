using KushtPor.Clients;
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

            // navigate to menues page
            //this.NavigationService.Navigate(new Pages.Menues(accesstoken, this.UserName.Text));
        }
    }
}
