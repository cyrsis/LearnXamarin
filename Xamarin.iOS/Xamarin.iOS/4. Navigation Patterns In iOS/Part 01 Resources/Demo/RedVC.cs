using System;
using UIKit;

namespace SimpleStack
{
	public class RedVC : UIViewController
	{
		public RedVC ()
		{
			this.Title = "Red";
		}

		public override void ViewDidLoad ()
		{
			this.View.BackgroundColor = UIColor.Red;

			var myButton = UIButton.FromType (UIButtonType.RoundedRect);
			myButton.SetTitle ("Go Back", UIControlState.Normal);

			myButton.Frame = new CoreGraphics.CGRect (0, 0, 100, 30);
			myButton.Center = this.View.Center;

			this.Add (myButton);

			myButton.TouchUpInside += (object sender, EventArgs e) => 
			{
				this.NavigationController.PopViewController(true);

			};

			//this.NavigationController.HidesBarsWhenVerticallyCompact = true;

			base.ViewDidLoad ();
		}
	}
}

