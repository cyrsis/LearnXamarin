using Foundation;
using System;
using UIKit;
using System.Threading;
using System.Threading.Tasks;

namespace CancellableTasks
{
	partial class CancellableTaskViewController : UIViewController
	{
		public CancellableTaskViewController (IntPtr handle) : base (handle)
		{
		}

		// TODO: Add a CancellationTokenSource.

		/// <summary>
		/// Return TRUE if the controller is currently calculating decimals.
		/// </summary>
		public bool IsCalculating
		{
			get;
			private set;
		}

		/// <summary>
		/// Gets called when the button to calculate Pi is pressed.
		/// </summary>
		/// <param name="sender">Sender</param>
		async partial void HandleCalculatePi (UIButton sender)
		{
			// Toggle status.
			if (this.IsCalculating)
			{
				this.IsCalculating = false;
				btnCalculate.SetTitle ("Start calculating", UIControlState.Normal);

				// TODO: Cancel calculation if it is currently running.
				return;
			}
	
			this.IsCalculating = true;
			btnCalculate.SetTitle ("Stop calculating", UIControlState.Normal);
			this.txtPi.Text = string.Empty;

			// TODO: Reset cancellation token source.

			// Start a background task to request more time from the operating system.
			// This has no negative side effect if called while the app is in the foreground.
			nint finiteTaskId = UIApplication.SharedApplication.BeginBackgroundTask (this.HandleBackgroundTimeExpires);

			// Now start calculating on a separate thread.
			// TODO: Pass token to Pi calculation and to the Task.Run() call.
			try
			{
				await Task.Run (() =>
   				    PiHelper.CalcPi (pieceOfPi => this.UpdateUi (pieceOfPi), default(CancellationToken)), 
					default(CancellationToken));
			}
			catch (OperationCanceledException)
			{
				Console.WriteLine ("Calculation canceled.");
				this.IsCalculating = false;
			}

			// Also end the background task.
			UIApplication.SharedApplication.EndBackgroundTask (finiteTaskId);
			finiteTaskId = -1;

			// Update the button's title.
			btnCalculate.SetTitle ("Start calculating", UIControlState.Normal);
		}

		/// <summary>
		/// Gets called whenever a new set of decimals has been calculated and is ready for displaying.
		/// </summary>
		/// <param name="pieceOfPi">Decimals of Pi</param>
		void UpdateUi (string pieceOfPi)
		{
			// TODO: Throw OperationCanceledException if token has been cancelled
		
			this.BeginInvokeOnMainThread (() => {
				// Report remaining background time if app is not in foreground.
				double backgroundTime = UIApplication.SharedApplication.BackgroundTimeRemaining;
				if (backgroundTime < double.MaxValue)
				{
					Console.WriteLine ("Background time remaining: " + Math.Round (backgroundTime) + " seconds");
				}

				Console.WriteLine ("A bit of Pi: " + pieceOfPi);

				// Update UI.
				this.txtPi.Text += " " + pieceOfPi;
				var range = new NSRange (txtPi.Text.Length - 1, 1);
				txtPi.ScrollRangeToVisible (range);
			});
		}

		/// <summary>
		/// This gets called if the available background time is about to expire.
		/// </summary>
		void HandleBackgroundTimeExpires ()
		{
			Console.WriteLine ("Background time expires - cancelling task!");
			// TODO: Cancel the token.
		}
	}
}
