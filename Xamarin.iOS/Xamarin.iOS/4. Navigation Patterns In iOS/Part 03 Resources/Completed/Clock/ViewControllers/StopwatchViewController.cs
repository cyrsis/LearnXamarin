using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;
using System.Timers;
using System.Collections.Generic;
using System.Diagnostics;

namespace Clock
{
	partial class StopwatchViewController : UIViewController
	{
		private List<TimeSpan> listSplits = new List<TimeSpan> ();

		private Timer swTimer;
		private DateTime dtStarted, dtLastSplit;
		private bool started = false;

		private string tsFormat = @"%m\:ss\.fff";

		public StopwatchViewController (IntPtr handle) : base (handle)
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			btnStart.TouchUpInside += BtnStart_TouchUpInside;
			btnSplit.TouchUpInside += BtnSplit_TouchUpInside;

			btnViewSplits.TouchUpInside += BtnViewSplits_TouchUpInside;
		}

		void BtnViewSplits_TouchUpInside (object sender, EventArgs e)
		{
			var splitsVS = (SplitsViewController)Storyboard.InstantiateViewController ("SplitsViewController");

			if (splitsVS == null)
				return;

			//don't forget to pass the split time data
			splitsVS.SplitTimes = this.listSplits;

			var navVC = new UINavigationController (splitsVS);


			PresentModalViewController (navVC, true);
		}

		void BtnSplit_TouchUpInside (object sender, EventArgs eArgs)
		{
			if (started == false) 
			{
				if(swTimer != null)
					swTimer.Stop ();
				swTimer = null;
				lblLastSplit.Text = lblElapsed.Text = "0:00.000";

				listSplits.Clear ();
			} 
			else //reset
			{
				dtLastSplit = DateTime.Now;
				var lap = (dtLastSplit - dtStarted);
				listSplits.Add (lap);
			}
		}

		void BtnStart_TouchUpInside (object sender, EventArgs eArgs)
		{
			if (started == false) 
			{
				if (swTimer == null) 
				{
					dtStarted = DateTime.Now;
					dtLastSplit = dtStarted;

					swTimer = new Timer (20);
					swTimer.Elapsed += (s, e) => UpdateUI ();
				}
				swTimer.Start ();

				btnStart.SetTitle ("Pause", UIControlState.Normal);
				btnSplit.SetTitle ("Split", UIControlState.Normal);
			} 
			else 
			{ 	
				swTimer.Stop ();
				btnStart.SetTitle ("Start", UIControlState.Normal);
				btnSplit.SetTitle ("Reset", UIControlState.Normal);
			}
			started = !started;
		}

		void UpdateUI ()
		{
			var ms = (DateTime.Now - dtStarted);
			var split = (DateTime.Now - dtLastSplit);

			BeginInvokeOnMainThread (() => {
				lblElapsed.Text = ms.ToString (tsFormat); 
				lblLastSplit.Text = String.Format("[Lap {0}] ", listSplits.Count + 1) + split.ToString(tsFormat);
			});
		}

	
	}
}
