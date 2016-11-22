using System;
using Android.Widget;
using Android.Content;
using Android.Views;
using Android.Util;

namespace Clock
{
	public class AlarmTimePicker : LinearLayout
	{
		NumberPicker hoursPicker;
		NumberPicker minutesPicker;
		NumberPicker secondsPicker;

		public AlarmTimePicker(Context context, IAttributeSet attrs)
			: base(context)
		{
			var inflater = LayoutInflater.From(context);
			inflater.Inflate(Resource.Layout.AlarmTimePicker, this, true);
			
			hoursPicker   = base.FindViewById<NumberPicker>(Resource.Id.hoursPicker  );
			minutesPicker = base.FindViewById<NumberPicker>(Resource.Id.minutesPicker);
			secondsPicker = base.FindViewById<NumberPicker>(Resource.Id.secondsPicker);
			
			hoursPicker  .MinValue = 0;
			hoursPicker  .MaxValue = 23;

			minutesPicker.MinValue = 0;
			minutesPicker.MaxValue = 59;

			secondsPicker.MinValue = 0;
			secondsPicker.MaxValue = 59;
		}

		public TimeSpan Value
		{
			get
			{
				return TimeSpan.FromSeconds(hoursPicker.Value * 3600 + minutesPicker.Value * 60 + secondsPicker.Value);
			}
		}

		public void SetToZero()
		{
			hoursPicker  .Value = 0;
			minutesPicker.Value = 0;
			secondsPicker.Value = 0;
		}

		public override bool Enabled
		{
			get
			{
				return base.Enabled;
			}
			set
			{
				hoursPicker  .Enabled = value;
				minutesPicker.Enabled = value;
				secondsPicker.Enabled = value;

				base.Enabled = value;
			}
		}
	}
}

