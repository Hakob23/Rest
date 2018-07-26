using KushtPor.ViewModels;
using System.Windows.Controls;

namespace KushtPor.Pages
{
    /// <summary>
    /// Interaction logic for Burgers.xaml
    /// </summary>
    public partial class Burgers : Page
    {
        private BurgerViewModel bvm;

        public Burgers(string accessToken, string name)
        {
            InitializeComponent();
            bvm = new BurgerViewModel(name, accessToken);
            List.ItemsSource = bvm.Burgers;
            this.DataContext = bvm;
        }
    }
}
