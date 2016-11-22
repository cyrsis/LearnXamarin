using System;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using UIKit;
using Foundation;
using System.Text;

namespace FiniteLengthTasks
{
	/// <summary>
	/// Simple controller that shows all logged data
	/// </summary>
	public partial class FiniteLengthTasksViewController : UIViewController
	{
		public FiniteLengthTasksViewController (IntPtr handle) : base (handle)
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			// If something has been logged, update the text view.
			Logger.LoggedData.CollectionChanged += (sender, e) => this.BeginInvokeOnMainThread (() => this.txtLog.Text = String.Join ("\n", Logger.LoggedData));;
		}
	}
}

