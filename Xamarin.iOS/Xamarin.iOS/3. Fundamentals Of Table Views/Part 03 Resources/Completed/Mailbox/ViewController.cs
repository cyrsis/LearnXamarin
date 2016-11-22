using System;

using UIKit;
using Foundation;
using CoreGraphics;

namespace Mailbox
{
    public partial class ViewController : UIViewController
    {
        class EmailServerDataSource : UITableViewSource
        {
            EmailServer emailServer = new EmailServer();

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

        public ViewController(IntPtr handle) : base(handle)
        {
        }

        UITableView tableView;
        EmailServerDataSource dataSource;

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.

            Add(tableView = new UITableView(this.View.Frame));

            tableView.BackgroundColor = UIColor.Yellow;
            tableView.TranslatesAutoresizingMaskIntoConstraints = false;

            tableView.ContentInset = new UIEdgeInsets(20, 0, 0, 0);

            View.AddConstraint(NSLayoutConstraint.Create(tableView, NSLayoutAttribute.Top,
                NSLayoutRelation.Equal, View, NSLayoutAttribute.TopMargin, 1, 0));
            View.AddConstraint(NSLayoutConstraint.Create(tableView, NSLayoutAttribute.Left,
                NSLayoutRelation.Equal, View, NSLayoutAttribute.Left, 1, 0));
            View.AddConstraint(NSLayoutConstraint.Create(tableView, NSLayoutAttribute.Width,
                NSLayoutRelation.Equal, View, NSLayoutAttribute.Width, 1, 0));
            View.AddConstraint(NSLayoutConstraint.Create(tableView, NSLayoutAttribute.Height,
                NSLayoutRelation.Equal, View, NSLayoutAttribute.Height, 1, 0));

            tableView.Source = dataSource = new EmailServerDataSource();
        }
    }
}

