using KushtPor.Clients;
using KushtPor.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Navigation;

namespace KushtPorForUsers.ViewModels
{
    class RegistrationViewModel : INotifyPropertyChanged
    {
        

        private RegistrationClient apiClient;
        private NavigationService ns;

        public RegistrationViewModel(NavigationService ns)
        {
            apiClient = new RegistrationClient();
            _canExecute = true;
            this.ns = ns;
        }

        public event PropertyChangedEventHandler PropertyChanged = delegate { };

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

        // email
        private string email;

        public string Email
        {
            get { return email; }
            set
            {
                email = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Email"));
            }
        }

        // email
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
        private ICommand _clickCommand;

        public ICommand NextCommand
        {
            get
            {
                return _clickCommand ?? (_clickCommand = new CommandHandler(() => MyAction(), _canExecute));
            }
        }

        private bool _canExecute;

        public void MyAction()
        {
            var user = new User();
            user.UserName = username;
            user.Email = this.email;
            user.Password = this.password;
            user.Role = "restaurant";
            var httpResponse = apiClient.RegisterUser(user);
            if (httpResponse.IsSuccessStatusCode)
            {
                ns.Navigate(new Pages.Verify());
            }
        }
    }
}
