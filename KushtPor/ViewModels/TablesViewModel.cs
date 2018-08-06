using KushtPor.Commands;
using KushtPor.Models;
using Newtonsoft.Json;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace KushtPor.ViewModels
{
    /// <summary>
    /// Tables view model
    /// </summary>
    public class TablesViewModel:INotifyPropertyChanged
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
        private double check;
        public double Check { get { return check; } set { check = value; OnPropertyChanged("Check"); } }
           
        /// <summary>
        /// All Tables
        /// </summary>
        public ObservableCollection<RestTable> Tables { get; set; } = new ObservableCollection<RestTable>();

        /// <summary>
        /// Orders
        /// </summary>
        public ObservableCollection<Order> Orders { get; set; } = new ObservableCollection<Order>();

        /// <summary>
        /// Selected Order
        /// </summary>
        public Order SelectedOrder { get; set; }

        // <summary>
        /// Delete button command
        /// </summary>
        public RelayCommand DeleteOrder { get; set; }

        /// <summary>
        /// Order delete function
        /// </summary>
        public void DeleteOrd()
        {
            Check -= SelectedOrder.Price;
            this.Orders.Remove(SelectedOrder);
        }

        public RestTable selectTab;

        /// <summary>
        /// Selected table
        /// </summary>
        public RestTable SelectedTable { get { return selectTab; }
            set
            {
                selectTab = value;
                GetOrders();
            }
        }

        public void GetOrders()
        {
            var client = new HttpClient();

            // initialize base address
            client.BaseAddress = new Uri("http://localhost:5005/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
       //     client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            // get response
            var response = client.GetAsync($"api/orders/{SelectedTable.Id}").Result;

            // if success
            if (response.IsSuccessStatusCode)
            {
                var ord = response.Content.ReadAsAsync<ObservableCollection<Order>>().Result;
                if (this.Orders != null)
                {
                    this.Orders.Clear();
                }
                double result = 0;
                foreach (var o in ord)
                {
                    result += o.Price;
                    this.Orders.Add(o);
                }
                this.Check = result;
            }
        }

        /// <summary>
        /// Delete button command
        /// </summary>
        public RelayCommand Delete { get; set; }

        /// <summary>
        /// Add button command
        /// </summary>
        public RelayCommand Add { get; set; }

        private string accessToken;

        private string username;

        private HttpClient client;
        
        public TablesViewModel(string accessToken, string username)
        {
            // create http client instance
            client = new HttpClient();

            // initialize base address
            client.BaseAddress = new Uri("http://localhost:5005/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            // get response
            var response = client.GetAsync($"api/restaurants/{username}/1").Result;

            // if success
            if (response.IsSuccessStatusCode)
            {
                // init Alchohol Drinks
                this.Tables = response.Content.ReadAsAsync<ObservableCollection<RestTable>>().Result;
            }
            var table = new RestTable();
            table.Id = 0;
            table.RestaurantName = username;
            this.Tables.Add(table);

            this.accessToken = accessToken;
            this.username = username;
            Add = new RelayCommand(() => AddTable(), o => true);
            Delete = new RelayCommand(() => DeleteTable(), o => true);
            DeleteOrder = new RelayCommand(() => DeleteOrd(), o => true);
        }

        public async Task AddTable()
        {
            // get response
            var response = await client.PostAsync($"api/restaurants/{username}", null);

            // if success
            if (response.IsSuccessStatusCode)
            {
                // get response
                response = await client.GetAsync($"api/restaurants/{username}/1");

                // if success
                if (response.IsSuccessStatusCode)
                {
                    // init Alchohol Drinks
                    var result = await response.Content.ReadAsAsync<ObservableCollection<RestTable>>();
                    Tables.Add(result[result.Count - 1]);
                }
            }
        }

        public void DeleteTable()
        {
            if (selectTab.Id != 0)
            {
                var request = new HttpRequestMessage(HttpMethod.Delete, $"api/restaurants");
                request.Content = new StringContent(JsonConvert.SerializeObject(SelectedTable), Encoding.UTF8, "application/json");
                var response = this.client.SendAsync(request).Result;

                // if success
                if (response.IsSuccessStatusCode)
                {
                    // init Alchohol Drinks
                    Tables.Remove(SelectedTable);
                }
            }
        }
    }
}
