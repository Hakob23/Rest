﻿using System.Windows.Controls;

namespace KushtPor.Pages
{
    /// <summary>
    /// Interaction logic for Menues.xaml
    /// </summary>
    public partial class Menues : Page
    {
        string userName;
        string accesToken;


        public Menues()
        {
            InitializeComponent();

        }

        public Menues(string accesToken, string userName)
        {
            this.userName = userName;
            this.accesToken = accesToken;

            InitializeComponent();
            this.menu.OnNavigateParentReady += MyControl_OnNavigateParentReady;
            
        }

        private void MyControl_OnNavigateParentReady(string name)
        {
            switch (name)
            {
                case "AlcoholDrinks":
                    secondFrame.Navigate(new Pages.AlcoholDrinks(accesToken, userName));
                    break;

                case "Burgers":
                    secondFrame.Navigate(new Pages.Burgers(accesToken, userName));
                    break;

                case "Drinks":
                    secondFrame.Navigate(new Pages.Drinks(accesToken, userName));
                    break;

                case "HotMeals":
                    secondFrame.Navigate(new Pages.HotMeals(accesToken, userName));
                    break;

                case "Pizzas":
                    secondFrame.Navigate(new Pages.Pizzas(accesToken, userName));
                    break;

                case "Salads":
                    secondFrame.Navigate(new Pages.Salads(accesToken, userName));
                    break;

                case "Soups":
                    secondFrame.Navigate(new Pages.Soups(accesToken, userName));
                    break;
            }

        }

        private void OrderButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            this.menu.Visibility = System.Windows.Visibility.Collapsed;
            this.order.Visibility = System.Windows.Visibility.Visible;
            secondFrame.Navigate(new Pages.Tables(accesToken, userName));
        }

        private void MenuButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            this.menu.Visibility = System.Windows.Visibility.Visible;
            this.order.Visibility = System.Windows.Visibility.Collapsed;
        }
    }
}
