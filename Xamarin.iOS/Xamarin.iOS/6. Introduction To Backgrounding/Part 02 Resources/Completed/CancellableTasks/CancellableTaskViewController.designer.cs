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

namespace CancellableTasks
{
	[Register ("CancellableTaskViewController")]
	partial class CancellableTaskViewController
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton btnCalculate { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITextView txtPi { get; set; }

		[Action ("HandleCalculatePi:")]
		[GeneratedCode ("iOS Designer", "1.0")]
		partial void HandleCalculatePi (UIButton sender);

		void ReleaseDesignerOutlets ()
		{
			if (btnCalculate != null) {
				btnCalculate.Dispose ();
				btnCalculate = null;
			}
			if (txtPi != null) {
				txtPi.Dispose ();
				txtPi = null;
			}
		}
	}
}
