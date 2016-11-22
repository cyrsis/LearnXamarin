using System;
using Xamarin.Forms;

namespace SpicyUI
{
	public partial class App : Application
	{
		public App ()
		{
			InitializeComponent ();

			MainPage = new NavigationPage (new WelcomePage ());
		}
	}
}