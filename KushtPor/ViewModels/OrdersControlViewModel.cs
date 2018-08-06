using KushtPor.Commands;
using KushtPor.Models;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace KushtPor.ViewModels
{
    public class OrdersControlViewModel:INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }

        public string Address { get; set; }

        public Order DelOrder { get; set; }

        private Order AddOrders { get; set; }

        private double bill;
        public double Bill
        {
            get
            {
                return bill;
            }
            set
            {
                bill = value;
                OnPropertyChanged("Bill");
            }
        }

        public ObservableCollection<Order> Orders { get; set; }

        public RelayCommand Order { get; set; }

        public RelayCommand Delete { get; set; }

        public OrdersControlViewModel()
        {
            //Order = new RelayCommand(() => AddOrder(this.DelOrder), o => true);
            Orders = new ObservableCollection<Order>();

            Delete = new RelayCommand(() => DeleteOrder(), o => true);
            Order = new RelayCommand(() => DoOrderAsync(), o => true);

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
            Bill += ord.Price;
            Orders.Add(ord);
        }

        public void DeleteOrder()
        {
            Bill -= this.DelOrder.Price;
            Orders.Remove(this.DelOrder);
        }

        public async Task DoOrderAsync()
        {
            foreach (var ord in Orders)
            {
                ord.Address = Address;
            }

            // create http client instance
            var client = new HttpClient();

            // initialize base address
            client.BaseAddress = new Uri("http://localhost:5005/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            foreach (var ord in Orders)
            {
                // get response
                var response = await client.PostAsJsonAsync($"api/orders", ord);
            }

            Orders.Clear();
        }
    }
}
