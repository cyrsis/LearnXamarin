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

namespace WeatherSettings
{
	[Register ("SettingsViewController")]
	partial class SettingsViewController
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel CellAddCity { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITableViewCell CellAlerts { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITableViewCell CellDefaultCity { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITableViewCell CellManageCities { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITableViewCell CellUnits { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UISwitch SwitchAlerts { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UISwitch SwitchUnits { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (CellAddCity != null) {
				CellAddCity.Dispose ();
				CellAddCity = null;
			}
			if (CellAlerts != null) {
				CellAlerts.Dispose ();
				CellAlerts = null;
			}
			if (CellDefaultCity != null) {
				CellDefaultCity.Dispose ();
				CellDefaultCity = null;
			}
			if (CellManageCities != null) {
				CellManageCities.Dispose ();
				CellManageCities = null;
			}
			if (CellUnits != null) {
				CellUnits.Dispose ();
				CellUnits = null;
			}
			if (SwitchAlerts != null) {
				SwitchAlerts.Dispose ();
				SwitchAlerts = null;
			}
			if (SwitchUnits != null) {
				SwitchUnits.Dispose ();
				SwitchUnits = null;
			}
		}
	}
}
