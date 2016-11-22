using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;
using CoreGraphics;
using System.Runtime.ConstrainedExecution;

namespace Mailbox
{
	partial class TableViewController : UITableViewController
	{
        EmailServer emailServer = new EmailServer(1000);

		public TableViewController (IntPtr handle) : base (handle)
		{
		}

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            TableView.ContentInset = new UIEdgeInsets(20, 0, 0, 0);
        }

        public override nint RowsInSection(UITableView tableview, nint section)
        {
            return emailServer.Email.Count;
        }

        const string CellId = "EmailCell";

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            UITableViewCell cell = tableView.DequeueReusableCell(CellId, indexPath);
            if (cell.ImageView.Image != null) {
                cell.ImageView.Image.Dispose();
            }

            var item = emailServer.Email[indexPath.Row];

            cell.TextLabel.Text = item.Subject.Substring(0,20) + "...";
            cell.ImageView.Image = item.GetImage();
            cell.DetailTextLabel.Text = item.Body;

            return cell;
        }
	}
}
