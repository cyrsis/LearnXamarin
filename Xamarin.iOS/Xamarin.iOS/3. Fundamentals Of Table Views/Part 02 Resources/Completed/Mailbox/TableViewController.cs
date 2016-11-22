using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;
using CoreGraphics;

namespace Mailbox
{
	partial class TableViewController : UITableViewController
	{
        EmailServer emailServer = new EmailServer();

		public TableViewController (IntPtr handle) : base (handle)
		{
		}

        public override nint RowsInSection(UITableView tableview, nint section)
        {
            return emailServer.Email.Count;
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            UITableViewCell cell = new UITableViewCell(CGRect.Empty);
            var item = emailServer.Email[indexPath.Row];

            cell.TextLabel.Text = item.Subject;
            return cell;
        }
	}
}
