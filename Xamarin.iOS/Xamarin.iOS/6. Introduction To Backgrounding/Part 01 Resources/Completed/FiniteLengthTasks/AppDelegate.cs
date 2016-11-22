using UIKit;
using System.Threading;
using System;
using System.Threading.Tasks;

namespace FiniteLengthTasks
{
	public class AppDelegate : UIApplicationDelegate
	{
		nint taskId = -1;

		public async override void DidEnterBackground (UIApplication app)
		{
			Logger.Log ("DidEnterBackground() - entered background");

			// Begin Finite-Length Task.
			this.taskId = app.BeginBackgroundTask (null);

			// Start saving the user choices.
			// Note that the method will by default execute on the UI thread. If you go back to the app while the method
			// is running, you won't see any UI updates and the app will eventually crash. That's why we run it on a separate thread.
			await Task.Run (() => this.SaveUserChoices ());

			// End Finite-Length Task, finished.
			if (this.taskId != -1)
			{
				UIApplication.SharedApplication.EndBackgroundTask (this.taskId);
				this.taskId = -1;
			}
		}

		public override void WillEnterForeground (UIApplication app)
		{
			Logger.Log ("WillEnterForeground() - coming from background into foreground");
			// End task, no longer needed.
			if (this.taskId != -1)
			{
				app.EndBackgroundTask (this.taskId);
				this.taskId = -1;
			}
		}

		/// <summary>
		/// Simulates saving some state. This method will run for 20 seconds.
		/// </summary>
		void SaveUserChoices ()
		{
			Logger.Log ("Start saving choices...");
			for (int i = 0; i < 20; i++)
			{
				Logger.Log ("  Saving choice: [{0}]...", (i + 1));
				Thread.Sleep (1000);
			}
			Logger.Log ("Done saving choices.");
		}

#region Other lifecycle methods and initialization code
		public override UIWindow Window
		{
			get;
			set;
		}

		public override bool FinishedLaunching (UIApplication app, Foundation.NSDictionary launchOptions)
		{
			Logger.Log ("Finite-Length Tasks Demo. Press home button to start a Finite-Length Task.");
			Logger.Log ("FinishedLaunching() - started from scratch");
			return true;
		}

		public override void OnActivated (UIApplication app)
		{
			Logger.Log ("OnActivated() - app is now active");
		}

		public override void OnResignActivation (UIApplication app)
		{
			Logger.Log ("OnResignActivation() - currently inactive");
		}

		public override void WillTerminate (UIApplication app)
		{
			Logger.Log ("WillTerminate()");
		}
#endregion
	}
}
