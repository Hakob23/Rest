using KushtPor.Commands;
using KushtPor.Models;
using System.Collections.ObjectModel;

namespace KushtPor.ViewModels
{
    public class OrdersControlViewModel
    {
        public Order DelOrder { get; set; }

        private Order AddOrders { get; set; }

        public ObservableCollection<Order> Orders { get; set; }

        public RelayCommand Order { get; set; }

        public RelayCommand Delete { get; set; }

        public OrdersControlViewModel()
        {
            //Order = new RelayCommand(() => AddOrder(this.DelOrder), o => true);
            Orders = new ObservableCollection<Order>();

            Delete = new RelayCommand(() => DeleteOrder(), o => true);

            AlcoholDrinkForUserViewModel.OrdEventAD += AddOrder;
            BurgersForUserViewModel.OrdEventBurg += AddOrder;
            DrinksForUserViewModel.OrdEventDrink += AddOrder;
            HotMealsForUserViewModel.OrdEventHotMeal += AddOrder;
            PizzasForUserViewModel.OrdEventPizzas += AddOrder;
            SaladsForUserViewModel.OrdEventSalads += AddOrder;
            SoupsForUserViewModel.OrdEventSoups += AddOrder;
        }

        public void AddOrder(Order ord)
        {
            Orders.Add(ord);
        }

        public void DeleteOrder()
        {
            Orders.Remove(this.DelOrder);
        }
    }
}
