using Android.App;
using Android.OS;
using Android.Util;

namespace Demo1Lifecycle
{
	[Activity(Label = "MemoryEaterActivity")]			
	public class MemoryEaterActivity : Activity
	{
		const string logTag = "MemoryEater";

		public MemoryEaterActivity ()
		{
			Log.Debug (logTag, "Constructor");
		}

		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);

			Log.Debug(logTag, "OnCreate called");
		}

		protected override void OnStart()
		{
			Log.Debug(logTag, "OnStart called - allocating memory.");

			base.OnStart();

			var ii = new int[1000000000];
			ii[0] = 10;
		}

		protected override void OnResume()
		{
			Log.Debug (logTag, "OnResume called, Activity is ready to interact with the user");
			base.OnResume();
		}

		protected override void OnPause()
		{
			Log.Debug (logTag, "OnPause called, Activity is moving to background");
			base.OnPause();
		}

		protected override void OnStop()
		{
			Log.Debug (logTag, "OnStop called, Activity is in the background");
			base.OnStop();
		}

		protected override void OnRestart()
		{
			Log.Debug (logTag, "OnRestart called, Activity is returning from background");
			base.OnRestart();
		}

		protected override void OnDestroy ()
		{
			base.OnDestroy ();
			Log.Debug (logTag, "OnDestroy called, Activity is Terminating");
		}
	}
}