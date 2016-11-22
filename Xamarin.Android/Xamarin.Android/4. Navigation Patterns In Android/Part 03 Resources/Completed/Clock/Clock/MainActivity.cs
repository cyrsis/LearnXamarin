﻿using Android.App;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Support.V4.Widget;
using Android.Support.V7.App;

namespace Clock
{
	[Activity(Label = "Clock", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : Activity
	{
		DrawerLayout          drawerLayout;
		ActionBarDrawerToggle drawerToggle;
		ListView              drawerListView;

		Fragment[] fragments = new Fragment[] { new TimeFragment(), new StopwatchFragment(), new AlarmFragment(), new AboutFragment() };
		string  [] titles    = new string  [] {    "Time",             "Stopwatch",             "Alarm",             "About"          };
		
		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);
			SetContentView(Resource.Layout.Main);

			//
			// Retrieve the DrawerLayout from the XML
			//
			drawerLayout = FindViewById<DrawerLayout>(Resource.Id.drawerLayout);

			//
			// Create an instance of ActionBarDrawerToggle
			//
			drawerToggle = new ActionBarDrawerToggle(this, drawerLayout, Resource.String.DrawerOpenDescription, Resource.String.DrawerCloseDescription);

			//
			// Set the ActionBarDrawerToggle as a DrawerListener on the DrawerLayout so it receives drawer state-change callbacks
			//
			drawerLayout.SetDrawerListener(drawerToggle);

			// 
			// Must up-enable the home button, the ActionBarDrawerToggle will change the icon to the "hamburger"
			//
			ActionBar.SetDisplayHomeAsUpEnabled(true); 

			//
			// Prepare the ListView that will serve as the menu
			//
			drawerListView = FindViewById<ListView>(Resource.Id.drawerListView);
			drawerListView.Adapter = new ArrayAdapter<string>(this, Resource.Layout.ListViewMenuRow, Resource.Id.menuRowTextView, titles);
			drawerListView.ItemClick += (object sender, AdapterView.ItemClickEventArgs e) => OnMenuItemClick(e.Position);
			drawerListView.SetItemChecked(0, true);	// Highlight the first item at startup
			OnMenuItemClick(0);                     // Load Fragment 0 at startup
		}

		protected override void OnPostCreate(Bundle savedInstanceState)
		{
			//
			// Initialization and any needed Restore operation are now complete.
			// Sync the state of the ActionBarDrawerToggle to the drawer (i.e. show the "hamburger" if the drawer is closed or an arrow if it is open).
			//
			drawerToggle.SyncState();

			base.OnPostCreate(savedInstanceState);
		}

		void OnMenuItemClick(int position)
		{
			//
			// Show the selected Fragment to the user
			//
			base.FragmentManager.BeginTransaction().Replace(Resource.Id.frameLayout, fragments[position]).Commit();

			//
			// Update the Activity title in the ActionBar
			//
			this.Title = titles[position];

			//
			// Close the drawer
			//
			drawerLayout.CloseDrawer(drawerListView);
		}

		public override bool OnOptionsItemSelected(IMenuItem item)
		{
			//
			// Forward all ActionBar-clicks to the ActionBarDrawerToggle.
			// It will verify the click was on the "Home" button (i.e. the button at the left edge of the ActionBar).
			// If so, it will toggle the state of the drawer. It will then return "true" so you know you do not need to do any more processing.
			//
			if (drawerToggle.OnOptionsItemSelected(item))
				return true;

			//
			// Other cases go here for other buttons in the ActionBar.
			// This sample app has no other buttons. This code is a placeholder to show what would be needed if there were other buttons.
			//
			switch (item.ItemId)
			{
				default: break;
			}

			return base.OnOptionsItemSelected(item);
		}
	}
}