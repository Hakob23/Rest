using KushtPor.ViewModels;
using System.Windows.Controls;
using System.Windows.Documents;

namespace KushtPor.Pages
{
    /// <summary>
    /// Interaction logic for Soups.xaml
    /// </summary>
    public partial class Soups : Page
    {
        private SoupViewModel svm;

        public Soups(string accessToken, string name)
        {
            InitializeComponent();
            svm = new SoupViewModel(name, accessToken);
            List.ItemsSource = svm.Soups;
            this.DataContext = svm;
        }
    }
}
