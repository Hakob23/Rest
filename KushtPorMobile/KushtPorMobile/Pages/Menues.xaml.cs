using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace KushtPorMobile.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Menues : ContentPage
	{
		public Menues ( string username, string accessToken)
		{
			InitializeComponent ();
		}
	}
}