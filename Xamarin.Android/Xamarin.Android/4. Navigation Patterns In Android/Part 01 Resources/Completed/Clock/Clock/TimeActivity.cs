using Android.OS;
using Android.Widget;
using System.Timers;
using Android.App;

namespace Clock
{
	[Activity(Label = "Time", Icon = "@drawable/icon")]
	public class TimeActivity : Activity
	{
		TextView timeTextView;
		Timer    timer;

		public TimeActivity()
		{
			timer = new Timer(1000);
			timer.Elapsed += OnElapsed;
			timer.Start();
		}

		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);
			SetContentView(Resource.Layout.Time);

			timeTextView = FindViewById<TextView>(Resource.Id.timeTextView);

			timeTextView.Text = System.DateTime.Now.ToString("T");
		}

		void OnElapsed(object sender, ElapsedEventArgs e)
		{
			this.RunOnUiThread(() => timeTextView.Text = System.DateTime.Now.ToString("T"));
		}
	}
}