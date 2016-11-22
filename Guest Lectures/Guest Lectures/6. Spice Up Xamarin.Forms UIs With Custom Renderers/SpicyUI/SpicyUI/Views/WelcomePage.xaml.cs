using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace SpicyUI
{
	public partial class WelcomePage : ContentPage
	{
		public WelcomePage ()
		{
			NavigationPage.SetHasNavigationBar (this, false);
			BindingContext = new WelcomeViewModel (this);

			InitializeComponent ();
		}

		private WelcomeViewModel ViewModel
		{
			get { return BindingContext as WelcomeViewModel; }
		}
	}
}