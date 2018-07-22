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
    /// Interaction logic for Burgers.xaml
    /// </summary>
    public partial class Burgers : Page
    {
        string userName;
        string accesToken;

        public Burgers(string accessToken, string name)
        {
            InitializeComponent();
        }
    }
}
