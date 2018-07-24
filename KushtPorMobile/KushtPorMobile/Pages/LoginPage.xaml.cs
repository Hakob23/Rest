using KushtPorMobile.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace KushtPorMobile.Pages
{
    /// <summary>
    /// Login view
    /// </summary>
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LoginPage : ContentPage
	{
        // login view model instance
        public LoginViewModel lvm;

        /// <summary>
        /// Login page constructor
        /// </summary>
        public LoginPage ()
		{
            InitializeComponent();

            MessagingCenter.Subscribe<LoginViewModel, string>(this, "LoginAlert", (sender, username) =>
            {
                DisplayAlert("Title", username, "OK");
            });

            // creating login view model instance
            lvm = new LoginViewModel();

            // set navigation
            lvm.Navigation = this.Navigation;

            this.BindingContext = lvm;

            // change focus if input completed
            username.Completed += (object sender, EventArgs e) =>
            {
                password.Focus();
            };

            // change docus if input completed
            password.Completed += (object sender, EventArgs e) =>
            {
                lvm.SubmitCommand.Execute(null);
            };
        }
    }
}