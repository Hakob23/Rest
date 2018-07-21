using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KushtPor
{
    class ViewModel : INotifyPropertyChanged
    {
        public List<Menu> menus = new List<Menu>();

        public event PropertyChangedEventHandler PropertyChanged;

        public List<Menu> Menus
        {
            get { return menus; }
            set
            {
                this.menus = value;
                OnPropertyChanged("MenuChanged");
            }
        }

        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}
