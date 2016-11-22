using System;
using Xamarin.Forms;

namespace SpicyUI
{
	public class SpicyEntry : Entry
	{
		public static readonly BindableProperty BorderEnabledProperty =
			BindableProperty.Create<SpicyEntry, string> (p => p.BorderEnabled, "True");

		public string BorderEnabled {
			get { return (string)GetValue (BorderEnabledProperty); }
			set { SetValue (BorderEnabledProperty, value); }
		}
	}
}