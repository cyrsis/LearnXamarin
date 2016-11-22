// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace Clock
{
	[Register ("ClockViewController")]
	partial class ClockViewController
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel lblAmPm { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel lblSeconds { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel lblTime { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIView viewClockBackground { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (lblAmPm != null) {
				lblAmPm.Dispose ();
				lblAmPm = null;
			}
			if (lblSeconds != null) {
				lblSeconds.Dispose ();
				lblSeconds = null;
			}
			if (lblTime != null) {
				lblTime.Dispose ();
				lblTime = null;
			}
			if (viewClockBackground != null) {
				viewClockBackground.Dispose ();
				viewClockBackground = null;
			}
		}
	}
}
