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

namespace KushtPor.Control
{
    /// <summary>
    /// Interaction logic for TableOrdersControl.xaml
    /// </summary>
    public partial class TableOrdersControl : UserControl
    {
        public delegate void MyEventHandler(string name);

        public event MyEventHandler Navigate;

        public TableOrdersControl()
        {
            InitializeComponent();
        }

        private void Table_Click(object sender, RoutedEventArgs e)
        {
        }

        private void Menu_Click(object sender, RoutedEventArgs e)
        {
            Navigate("Menues");
        }
    }
}
