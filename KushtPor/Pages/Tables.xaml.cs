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
using KushtPor.ViewModels;

namespace KushtPor.Pages
{
    /// <summary>
    /// Interaction logic for Tables.xaml
    /// </summary>
    public partial class Tables : Page
    {
        private RestTableViewModel rtvm;

        public Tables(string accessToken, string name)
        {
            InitializeComponent();
            rtvm = new RestTableViewModel(name, accessToken);
            List.ItemsSource = rtvm.Tables;
            this.DataContext = rtvm;
        }
    }
}
