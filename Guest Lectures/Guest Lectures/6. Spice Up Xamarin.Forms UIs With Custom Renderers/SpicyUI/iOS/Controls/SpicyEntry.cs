using CoreAnimation;
using Foundation;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer (typeof (SpicyUI.SpicyEntry), typeof (SpicyUI.iOS.SpicyEntryRenderer))]
namespace SpicyUI.iOS
{
	public class SpicyEntryRenderer : EntryRenderer
	{
		protected override void OnElementChanged (ElementChangedEventArgs<Entry> e)
		{
			base.OnElementChanged (e);

			if (Control != null) {
				var spicyEntry = (SpicyEntry)Element;

				// Border Enabled
				if (spicyEntry.BorderEnabled == "True") {
					Control.BorderStyle = UITextBorderStyle.RoundedRect;
				} else {
					Control.BorderStyle = UITextBorderStyle.None;
				}
			}
		}
	}
}