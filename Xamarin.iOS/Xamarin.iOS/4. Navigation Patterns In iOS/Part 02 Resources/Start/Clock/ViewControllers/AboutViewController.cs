using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace Clock
{
	partial class AboutViewController : UIViewController
	{
		public AboutViewController (IntPtr handle) : base (handle)
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			EdgesForExtendedLayout = UIRectEdge.None;

			string aboutUrl = NSBundle.MainBundle.BundlePath + "/About.html";

			AboutWebView.LoadRequest (new NSUrlRequest (new NSUrl (aboutUrl, false)));
		}
	}
}
