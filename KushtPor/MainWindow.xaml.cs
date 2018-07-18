using KushtPor.ViewModel;
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
        public MainWindow()
        {
            InitializeComponent();

            this.DataContext = new WindowViewModel(this);
        }
    }
}
