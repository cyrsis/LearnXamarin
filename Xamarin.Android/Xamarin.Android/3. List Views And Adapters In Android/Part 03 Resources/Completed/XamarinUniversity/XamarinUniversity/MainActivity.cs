using Android.App;
using Android.OS;
using Android.Widget;

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
			instructorList.ItemClick += OnItemClick;

			instructorList.Adapter = new InstructorAdapter(InstructorData.Instructors);
		}

		void OnItemClick(object sender, AdapterView.ItemClickEventArgs e)
		{
			var instructor = InstructorData.Instructors[e.Position];

			var dialog = new AlertDialog.Builder(this);
			dialog.SetMessage(instructor.Name);
			dialog.SetNeutralButton("OK", delegate { });
			dialog.Show();
		}
	}
}