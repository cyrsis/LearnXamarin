using Android.OS;
using Android.App;

namespace Clock
{
	[Activity(Label = "About", Icon = "@drawable/icon")]
	public class AboutActivity : Activity
	{
		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);
			SetContentView(Resource.Layout.About);
		}
	}
}