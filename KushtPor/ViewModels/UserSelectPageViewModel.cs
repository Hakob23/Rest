using KushtPor.Commands;
using KushtPor.Pages;
using System.Windows.Navigation;

namespace KushtPor.ViewModels
{
    /// <summary>
    /// UserSelectPageViewModel
    /// </summary>
    public class UserSelectPageViewModel
    {
        /// <summary>
        /// AllRestaurants button command
        /// </summary>
        public RelayCommand AllRestaurants { get; set; }


        /// <summary>
        /// EnterId button command
        /// </summary>
        public RelayCommand EnterId { get; set; }

        private NavigationService navigate { get; set; }

        public UserSelectPageViewModel(NavigationService navigate)
        {
            this.navigate = navigate;

            AllRestaurants = new RelayCommand(() => GoToAllRestaurants(), o => true);
        }

        public void GoToAllRestaurants()
        {
            //navigate.Navigate(new AllRestaurants());
        }
    }
}
