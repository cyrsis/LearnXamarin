using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;
using System.Diagnostics;

namespace WeatherSettings
{
	partial class SettingsViewController : UITableViewController
	{
		public SettingsViewController (IntPtr handle) : base (handle)
		{
			
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			SwitchAlerts.ValueChanged += (sender, e) => Debug.WriteLine ("Alerts " + (SwitchAlerts.On ? "On" : "Off"));

			SwitchUnits.ValueChanged += (sender, e) => Debug.WriteLine ("Use " + (SwitchUnits.On ? "Celsius" : "Fahrenheit"));

			CellDefaultCity.DetailTextLabel.Text = "Virginia Beach";
		}

		public override void RowSelected (UITableView tableView, NSIndexPath indexPath)
		{
			Debug.WriteLine (String.Format ("Row {0} tapped", indexPath.Row));
		}

		public override void AccessoryButtonTapped (UITableView tableView, NSIndexPath indexPath)
		{
			Debug.WriteLine (String.Format ("Accessory {0} tapped", indexPath.Row));
		}
	}
}
