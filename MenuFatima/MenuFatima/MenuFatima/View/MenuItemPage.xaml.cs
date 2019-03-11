using MenuFatima.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MenuFatima.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MenuItemPage : ContentPage
	{
		public MenuItemPage ()
		{
			InitializeComponent ();
            BindingContext = new MenuItemViewModel();
		}
	}
}