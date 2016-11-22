using System;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer (typeof(SpicyUI.SpicyEntry), typeof(SpicyUI.Droid.SpicyEntry))]
namespace SpicyUI.Droid
{
	public class SpicyEntry : EntryRenderer
	{
		public SpicyEntry ()
		{
		}

		protected override void OnElementChanged (ElementChangedEventArgs<Entry> e)
		{
			base.OnElementChanged (e);

			if (Control != null) {
				Control.SetBackgroundDrawable (null);
			}
		}
	}
}

