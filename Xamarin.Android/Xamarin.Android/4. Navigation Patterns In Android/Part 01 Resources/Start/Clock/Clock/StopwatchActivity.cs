using System;
using Android.Widget;
using System.Timers;
using Android.OS;
using Android.App;

namespace Clock
{
	[Activity(Label = "Stopwatch", Icon = "@drawable/icon")]
	public class StopwatchActivity : Activity
	{
		TextView timeTextView;
		Button   startStopButton;
		Button   resetButton;
		Timer    timer;
		TimeSpan ticks;

		public StopwatchActivity()
		{
			timer = new Timer(1000);
			timer.Elapsed += OnElapsed;
		}

		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);
			SetContentView(Resource.Layout.Stopwatch);
		
			timeTextView    = FindViewById<TextView>(Resource.Id.timeTextView);
			startStopButton = FindViewById<Button  >(Resource.Id.startStopButton);
			resetButton     = FindViewById<Button  >(Resource.Id.resetButton);

			startStopButton.Click += OnStartStop;
			resetButton    .Click += OnReset;
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

			this.RunOnUiThread(() => timeTextView.Text = ticks.ToString("g"));
		}
	}
}