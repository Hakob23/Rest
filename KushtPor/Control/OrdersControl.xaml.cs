using KushtPor.ViewModels;
using System.Windows.Controls;

namespace KushtPor.Control
{
    /// <summary>
    /// Interaction logic for OrdersControl.xaml
    /// </summary>
    public partial class OrdersControl : UserControl
    {
        public OrdersControlViewModel viewModel;
        public OrdersControl()
        {
            viewModel = new OrdersControlViewModel();
            InitializeComponent();
            this.DataContext = viewModel;
        }
    }
}
