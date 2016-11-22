using Android.App;
using Android.OS;
using Android.Widget;
using Android.Content;

namespace XamarinUniversity
{
	[Activity(Label = "XamarinUniversity", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : Activity
	{
		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);
			SetContentView(Resource.Layout.Main);

			var instructorList = FindViewById<ListView>(Resource.Id.instructorListView);
			instructorList.FastScrollEnabled = true;
			instructorList.ItemClick += OnItemClick;

			instructorList.Adapter = new InstructorAdapter(InstructorData.Instructors);
		}

		void OnItemClick(object sender, AdapterView.ItemClickEventArgs e)
		{
			var intent = new Intent(this, typeof(InstructorDetailsActivity));

			intent.PutExtra("position", e.Position);

			StartActivity(intent);
		}
	}
}