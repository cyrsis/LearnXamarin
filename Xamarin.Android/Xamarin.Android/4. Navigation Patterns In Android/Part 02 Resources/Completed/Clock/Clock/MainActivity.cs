using Android.App;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace Clock
{
	[Activity(Label = "Clock", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : Android.Support.V4.App.FragmentActivity
	{
		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);
			SetContentView(Resource.Layout.Main);

			var fragments = new Android.Support.V4.App.Fragment[]
				{
					new TimeFragment     (),
					new StopwatchFragment(),
					new AboutFragment    ()
				};

			var titles = CharSequence.ArrayFromStringArray(new [] 
				{ 
					"Time", 
					"Stopwatch", 
					"About"
				});

			//
			// Use FindViewById to get a reference to the ViewPager in the UI
			//
			var viewPager = FindViewById<Android.Support.V4.View.ViewPager>(Resource.Id.viewPager);

			//
			// Create a ClockAdapter and assign it to the ViewPager's Adapter property
			//
			viewPager.Adapter = new ClockAdapter(base.SupportFragmentManager, fragments, titles);
		}
	}
}