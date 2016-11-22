using Android.OS;
using Android.Views;
using Android.Widget;
using System.Timers;

namespace Clock
{
	public class TimeFragment : Android.Support.V4.App.Fragment
	{
		TextView timeTextView;
		Timer    timer;

		public TimeFragment()
		{
			timer = new Timer(1000);
			timer.Elapsed += OnElapsed;
			timer.Start();
		}

		public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
		{
			var view = inflater.Inflate(Resource.Layout.Time, container, false);

			timeTextView = view.FindViewById<TextView>(Resource.Id.timeTextView);

			timeTextView.Text = System.DateTime.Now.ToString("T");

			return view;
		}

		void OnElapsed(object sender, ElapsedEventArgs e)
		{
			base.Activity.RunOnUiThread(() => timeTextView.Text = System.DateTime.Now.ToString("T"));
		}
	}
}