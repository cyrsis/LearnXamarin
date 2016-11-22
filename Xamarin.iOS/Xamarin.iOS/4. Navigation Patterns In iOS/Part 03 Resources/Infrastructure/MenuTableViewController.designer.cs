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
	[Register ("MenuTableViewController")]
	partial class MenuTableViewController
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITableView MyTableView { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (MyTableView != null) {
				MyTableView.Dispose ();
				MyTableView = null;
			}
		}
	}
}
