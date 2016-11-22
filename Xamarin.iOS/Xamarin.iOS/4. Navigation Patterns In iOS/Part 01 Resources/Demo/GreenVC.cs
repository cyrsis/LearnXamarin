using System;
using UIKit;

namespace SimpleStack
{
	public class GreenVC : UIViewController
	{
		public GreenVC ()
		{
			this.Title = "Green";
		}

		public override void ViewDidLoad ()
		{
			this.View.BackgroundColor = UIColor.Green;

			var myButton = UIButton.FromType (UIButtonType.RoundedRect);
			myButton.SetTitle ("Go To Red", UIControlState.Normal);

			myButton.Frame = new CoreGraphics.CGRect (0, 0, 100, 30);
			myButton.Center = this.View.Center;

			this.Add (myButton);

			myButton.TouchUpInside += (object sender, EventArgs e) => 
			{
				this.NavigationController.PushViewController(new RedVC(), true);
			};

			base.ViewDidLoad ();
		}
	}
}

