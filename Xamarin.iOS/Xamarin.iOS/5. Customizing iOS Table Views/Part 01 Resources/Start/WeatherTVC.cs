using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;
using System.Collections.Generic;

namespace WeatherApp
{
	partial class WeatherTVC : UITableViewController
	{
		const string CELL_ID = "id";
		List<Weather> data;

		public WeatherTVC (IntPtr handle) : base (handle)
		{
			data = WeatherFactory.GetWeatherData ();

			TableView.ContentInset = new UIEdgeInsets (this.TopLayoutGuide.Length, 0, 0, 0);
		}

		public override UITableViewCell GetCell (UITableView tableView, NSIndexPath indexPath)
		{
			var cell = tableView.DequeueReusableCell (CELL_ID);

			if (cell == null) {
				cell = new UITableViewCell (UITableViewCellStyle.Default, CELL_ID);
			}

			cell.TextLabel.Text = data [indexPath.Row].ToString ();

			return cell;
		}

		public override nint RowsInSection (UITableView tableview, nint section)
		{
			return data.Count;
		}





	}
}
