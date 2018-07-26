using KushtPor.ViewModels;
using System.Windows.Controls;
using System.Windows.Documents;

namespace KushtPor.Pages
{
    /// <summary>
    /// Interaction logic for HotMeals.xaml
    /// </summary>
    public partial class HotMeals : Page
    {
        private HotMealViewModel hmvm;

        public HotMeals(string accessToken, string name)
        {
            InitializeComponent();
            hmvm = new HotMealViewModel(name, accessToken);
            List.ItemsSource = hmvm.Meals;
            this.DataContext = hmvm;
        }
    }
}
