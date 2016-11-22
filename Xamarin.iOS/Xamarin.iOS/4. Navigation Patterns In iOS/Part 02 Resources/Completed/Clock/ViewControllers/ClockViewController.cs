using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;
using System.Timers;

namespace Clock
{
	partial class ClockViewController : UIViewController
	{
		Timer clockTimer;

		public ClockViewController (IntPtr handle) : base (handle)
		{
		}

		void UpdateTime ()
		{
			InvokeOnMainThread (() => {
				lblTime.Text = DateTime.Now.ToShortTimeString ();
				lblSeconds.Text = DateTime.Now.Second.ToString ("00");
				lblAmPm.Text = (DateTime.Now.Hour >= 12) ? "PM" : "AM";
			});
		}

		public override void ViewWillAppear (bool animated)
		{
			base.ViewWillAppear (animated);

			clockTimer = new Timer (1000);

			clockTimer.Elapsed += (s, e) => UpdateTime();
			clockTimer.Start ();


			UIApplication.Notifications.ObserveWillEnterForeground ((s, e) => {
				clockTimer.Start();
			});

			UIApplication.Notifications.ObserveDidEnterBackground ((s, e) => {
				clockTimer.Stop();
			});

			UpdateTime ();
		}

		public override void ViewWillDisappear (bool animated)
		{
			base.ViewWillDisappear (animated);

			clockTimer.Stop ();
			clockTimer = null;
		}
	}
}
