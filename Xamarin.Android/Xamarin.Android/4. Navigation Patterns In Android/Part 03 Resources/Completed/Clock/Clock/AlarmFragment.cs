using System;
using Android.OS;
using Android.Views;
using Android.Widget;
using System.Timers;
using Android.App;

namespace Clock
{
	public class AlarmFragment : Fragment
	{
		TextView        timeTextView;
		AlarmTimePicker alarmTimePicker;
		Button          startResetButton;

		TimeSpan ticks;
		Timer    timer;

		public AlarmFragment()
		{
			timer = new Timer(1000);
			timer.Elapsed += OnElapsed;
		}

		public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
		{
			var view = inflater.Inflate(Resource.Layout.Alarm, container, false);

			timeTextView     = view.FindViewById<TextView       >(Resource.Id.timeTextView    );
			alarmTimePicker  = view.FindViewById<AlarmTimePicker>(Resource.Id.alarmTimePicker );
			startResetButton = view.FindViewById<Button         >(Resource.Id.startResetButton);

			startResetButton.Click += OnStartReset;

			return view;
		}

		void OnStartReset(object sender, EventArgs e)
		{
			if (startResetButton.Text == "Start")
			{
				startResetButton.Text = "Reset";

				ticks = alarmTimePicker.Value;

				alarmTimePicker.Enabled = false;

				timer.Start();
			}
			else
			{
				Reset();
			}
		}

		void OnElapsed(object sender, ElapsedEventArgs e)
		{
			ticks = ticks.Subtract(TimeSpan.FromSeconds(1));

			UpdateTicksUI();

			if (ticks <= TimeSpan.Zero)
			{
				ShowAlert();
				Reset    ();
			}
		}

		void UpdateTicksUI()
		{
			base.Activity.RunOnUiThread(() => 
				{
					timeTextView.Text = ticks.ToString("g");
				});
		}

		void ShowAlert()
		{
			base.Activity.RunOnUiThread(() =>
				{
					var dialog = new AlertDialog.Builder(this.Activity);
					dialog.SetMessage("Time Elapsed");
					dialog.SetNeutralButton("OK", delegate {});
					dialog.Show();
				});
		}

		void Reset()
		{
			timer.Stop();
			ticks = TimeSpan.Zero;

			base.Activity.RunOnUiThread(() =>
				{					
					alarmTimePicker.SetToZero();

					alarmTimePicker.Enabled = true;

					UpdateTicksUI();

					startResetButton.Text = "Start";
				});
		}
	}
}