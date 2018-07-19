using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace KushtPor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //private static WindowViewModel wvm;

        public MainWindow()
        {
            InitializeComponent();
            MainFrame.Navigate(new Pages.Login());
            //wvm = new WindowViewModel(this);
            //this.DataContext = wvm;
        }

    }
}
