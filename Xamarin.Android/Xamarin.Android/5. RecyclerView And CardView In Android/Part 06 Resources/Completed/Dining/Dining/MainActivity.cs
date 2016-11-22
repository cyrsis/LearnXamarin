using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Support.V7.Widget;

namespace Dining
{
	[Activity(Label = "Dining", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : Activity
	{
		RecyclerView recyclerView;

		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);
			SetContentView(Resource.Layout.Main);

			recyclerView = FindViewById<RecyclerView>(Resource.Id.recyclerView);

			recyclerView.SetLayoutManager(new LinearLayoutManager(this, LinearLayoutManager.Vertical, false));

			var adapter = new RestaurantAdapter(SampleData.GetRestaurants());
			adapter.ItemClick += OnItemClick;

			recyclerView.SetAdapter(adapter);
		}

		void OnItemClick(object sender, int position)
		{
			System.Diagnostics.Debug.WriteLine("Click: " + position);
		}
	}
}