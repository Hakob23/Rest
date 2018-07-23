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
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LoginPage : ContentPage
	{
        public LoginViewModel lvm;

        public LoginPage ()
		{
            InitializeComponent();

            MessagingCenter.Subscribe<LoginViewModel, string>(this, "LoginAlert", (sender, username) =>
            {
                DisplayAlert("Title", username, "OK");
            });

            lvm = new LoginViewModel();

            this.BindingContext = lvm;

            username.Completed += (object sender, EventArgs e) =>
            {
                email.Focus();
            };

            email.Completed += (object sender, EventArgs e) =>
            {
                password.Focus();
            };

            password.Completed += (object sender, EventArgs e) =>
            {
                lvm.SubmitCommand.Execute(null);
            };
        }
    }
}