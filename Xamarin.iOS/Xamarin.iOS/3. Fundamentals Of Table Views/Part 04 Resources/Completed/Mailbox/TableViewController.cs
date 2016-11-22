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

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            TableView.ContentInset = new UIEdgeInsets(20, 0, 0, 0);
        }

        public override nint RowsInSection(UITableView tableview, nint section)
        {
            return emailServer.Email.Count;
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            UITableViewCell cell = new UITableViewCell(UITableViewCellStyle.Subtitle, null);
            var item = emailServer.Email[indexPath.Row];

            cell.TextLabel.Font = UIFont.FromName("Helvetica Light", 14);
            cell.DetailTextLabel.Font = UIFont.FromName("Helvetica Light", 12);
            cell.DetailTextLabel.TextColor = UIColor.LightGray;

            cell.TextLabel.Text = item.Subject.Substring(0,20) + "...";
            cell.ImageView.Image = item.GetImage();
            cell.DetailTextLabel.Text = item.Body;

            return cell;
        }
	}
}
