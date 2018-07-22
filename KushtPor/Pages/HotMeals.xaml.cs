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

namespace KushtPor.Pages
{
    /// <summary>
    /// Interaction logic for HotMeals.xaml
    /// </summary>
    public partial class HotMeals : Page
    {
        string userName;
        string accesToken;

        public HotMeals(string accessToken, string name)
        {
            InitializeComponent();
        }
    }
}
