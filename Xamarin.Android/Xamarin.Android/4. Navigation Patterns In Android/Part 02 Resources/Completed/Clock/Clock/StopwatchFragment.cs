using System;
using Android.OS;
using Android.Views;
using Android.Widget;
using System.Timers;

namespace Clock
{
	public class StopwatchFragment : Android.Support.V4.App.Fragment
	{
		TextView timeTextView;
		Button   startStopButton;
		Button   resetButton;
		Timer    timer;
		TimeSpan ticks;

		public StopwatchFragment()
		{
			timer = new Timer(1000);
			timer.Elapsed += OnElapsed;
		}

		public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
		{
			var view = inflater.Inflate(Resource.Layout.Stopwatch, container, false);

			timeTextView    = view.FindViewById<TextView>(Resource.Id.timeTextView);
			startStopButton = view.FindViewById<Button  >(Resource.Id.startStopButton);
			resetButton     = view.FindViewById<Button  >(Resource.Id.resetButton);

			startStopButton.Click += OnStartStop;
			resetButton    .Click += OnReset;

			return view;
		}

		void OnStartStop(object sender, EventArgs e)
		{
			if (startStopButton.Text == "Start")
			{
				startStopButton.Text = "Stop";
				timer.Start();
			}
			else
			{
				startStopButton.Text = "Start";
				timer.Stop();
			}
		}

		void OnReset(object sender, EventArgs e)
		{
			timer.Stop();
			timeTextView.Text = "0:00:00";
			startStopButton.Text = "Start";
			ticks = TimeSpan.Zero;
		}

		void OnElapsed(object sender, ElapsedEventArgs e)
		{
			ticks = ticks.Add(TimeSpan.FromSeconds(1));

			base.Activity.RunOnUiThread(() => timeTextView.Text = ticks.ToString("g"));
		}
	}
}