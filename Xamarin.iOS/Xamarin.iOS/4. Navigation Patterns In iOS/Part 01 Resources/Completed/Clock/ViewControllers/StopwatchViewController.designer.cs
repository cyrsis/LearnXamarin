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
	[Register ("StopwatchViewController")]
	partial class StopwatchViewController
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton btnSplit { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton btnStart { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton btnViewSplits { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel lblElapsed { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel lblLastSplit { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIView viewStopwatchBackground { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (btnSplit != null) {
				btnSplit.Dispose ();
				btnSplit = null;
			}
			if (btnStart != null) {
				btnStart.Dispose ();
				btnStart = null;
			}
			if (btnViewSplits != null) {
				btnViewSplits.Dispose ();
				btnViewSplits = null;
			}
			if (lblElapsed != null) {
				lblElapsed.Dispose ();
				lblElapsed = null;
			}
			if (lblLastSplit != null) {
				lblLastSplit.Dispose ();
				lblLastSplit = null;
			}
			if (viewStopwatchBackground != null) {
				viewStopwatchBackground.Dispose ();
				viewStopwatchBackground = null;
			}
		}
	}
}
