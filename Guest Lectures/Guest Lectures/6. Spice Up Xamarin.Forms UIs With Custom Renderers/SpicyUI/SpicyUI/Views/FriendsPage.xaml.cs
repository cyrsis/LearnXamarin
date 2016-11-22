using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace SpicyUI
{
	public partial class FriendsPage : ContentPage
	{
		public FriendsPage ()
		{
			BindingContext = new FriendViewModel ();
			Title = "Friends";

			InitializeComponent ();
		}

		private FriendViewModel ViewModel
		{
			get { return BindingContext as FriendViewModel; }
		}
	}
}

