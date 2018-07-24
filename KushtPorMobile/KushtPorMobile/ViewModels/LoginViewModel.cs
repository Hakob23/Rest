using KushtPorMobile.Clients;
using KushtPorMobile.Pages;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace KushtPorMobile.ViewModels
{
    /// <summary>
    /// Login View Model 
    /// </summary>
    public class LoginViewModel : INotifyPropertyChanged
    {
        // Property changed event
        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        // client
        private LoginClient client;

        // navigation object
        public INavigation Navigation { get; set; }

        //// email
        //private string email;
        //public string Email
        //{
        //    get { return email; }
        //    set
        //    {
        //        email = value;
        //        PropertyChanged(this, new PropertyChangedEventArgs("Email"));
        //    }
        //}

        // username
        private string username;

        public string Username
        {
            get { return username; }
            set
            {
                username = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Username"));
            }
        }

        // password
        private string password;
        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Password"));
            }
        }

        // login button
        public ICommand SubmitCommand { protected set; get; }
        
        /// <summary>
        /// Login View Model Constructor
        /// </summary>
        public LoginViewModel()
        {
            client = new LoginClient();
            SubmitCommand = new Command(OnSubmit);
        }

        public void OnSubmit()
        {
            if (string.IsNullOrEmpty(username))
            {
                MessagingCenter.Send(this, "LoginAlert", Username);
            }

            // getting accesstoken
            var accesstoken = client.LogIn(this.Username, this.Password);
            if (accesstoken != null)
            {
                // navigate to menues page
                this.Navigation.PushAsync(new Menues(username, accesstoken));
                //this.NavigationService.Navigate(new Menues(accesstoken, this.UserName.Text));
            }

        }
    }
}
