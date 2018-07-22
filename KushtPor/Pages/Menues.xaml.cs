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

        public Menues(string userName,string accesToken)
        {
            this.userName = userName;
            this.accesToken = accesToken;

            InitializeComponent();
            this.menu.OnNavigateParentReady += myControl_OnNavigateParentReady;
            //secondFrame.Navigate(new Pages.Login());
        }

        private void myControl_OnNavigateParentReady(string name)
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
    }
}
