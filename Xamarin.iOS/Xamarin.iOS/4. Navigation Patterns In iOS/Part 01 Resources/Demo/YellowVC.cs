using System;
using UIKit;

namespace SimpleStack
{
	public class YellowVC : UIViewController
	{
		public YellowVC ()
		{
			this.Title = "Yellow";
		}

		public override void ViewDidLoad ()
		{
			this.View.BackgroundColor = UIColor.Yellow;

			var myButton = UIButton.FromType (UIButtonType.RoundedRect);
			myButton.SetTitle ("Go To Green", UIControlState.Normal);

			myButton.Frame = new CoreGraphics.CGRect (0, 0, 100, 30);
			myButton.Center = this.View.Center;

			this.Add (myButton);

			myButton.TouchUpInside += (object sender, EventArgs e) => 
			{
				this.NavigationController.PushViewController(new GreenVC(), true);
			};

			base.ViewDidLoad ();

			SetNavBarButtons ();

		}

		void SetNavBarButtons ()
		{
		//	var btn =  new UIBarButtonItem (UIBarButtonSystemItem.Refresh);
		//	this.NavigationItem.RightBarButtonItem = btn;
		//	var alert = new UIAlertView ("Simple Stack", "Refresh Pressed", null, "OK", null);
		//	btn.Clicked += (sender, e) => alert.Show();

		//	this.NavigationItem.BackBarButtonItem = new UIBarButtonItem ("Go Back!!", UIBarButtonItemStyle.Plain, null);
		}
	}
}

