using KushtPor.ViewModels;
using System.Windows.Controls;
using System.Windows.Documents;

namespace KushtPor.Pages
{
    /// <summary>
    /// Interaction logic for Salads.xaml
    /// </summary>
    public partial class Salads : Page
    {
        private SaladViewModel svm;

        public Salads(string accessToken, string name)
        {
            InitializeComponent();
            svm = new SaladViewModel(name, accessToken);
            List.ItemsSource = svm.Salads;
            this.DataContext = svm;
        }
    }
}
