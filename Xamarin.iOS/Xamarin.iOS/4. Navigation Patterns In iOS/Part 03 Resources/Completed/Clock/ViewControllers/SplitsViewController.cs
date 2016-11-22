using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;
using System.Collections.Generic;

namespace Clock
{
	partial class SplitsViewController : UITableViewController
	{
		public List<TimeSpan> SplitTimes;

		public SplitsViewController (IntPtr handle) : base (handle)
		{

		}

		public override void ViewWillAppear (bool animated)
		{
			base.ViewWillAppear (animated);

			this.TableView.Source = new SplitsTableViewSource (SplitTimes);

			//add a right bar button item to dismiss the modal dialog
			var barButton = new UIBarButtonItem(UIBarButtonSystemItem.Done);
			barButton.Clicked += (sender, e) => DismissModalViewController(true);
			this.NavigationItem.RightBarButtonItem = barButton;
		}

		public class SplitsTableViewSource : UITableViewSource
		{
			private List<TimeSpan> splitTimes;

			private string tsFormat = @"%m\:ss\.fff";

			public SplitsTableViewSource (List<TimeSpan> splitTimes)
			{
				if(splitTimes != null)
					this.splitTimes = splitTimes;
				else
					this.splitTimes = new List<TimeSpan>();
			}

			#region implemented abstract members of UITableViewSource

			public override UITableViewCell GetCell (UITableView tableView, NSIndexPath indexPath)
			{
				var cell = tableView.DequeueReusableCell ("splitcellid");

				cell.TextLabel.Text = String.Format ("Lap {0}", indexPath.Row + 1);
				cell.DetailTextLabel.Text = splitTimes [indexPath.Row].ToString (tsFormat);
			
				return cell;
			}

			public override nint RowsInSection (UITableView tableview, nint section)
			{
				return splitTimes.Count;
			}

			#endregion
		}
	}
}
