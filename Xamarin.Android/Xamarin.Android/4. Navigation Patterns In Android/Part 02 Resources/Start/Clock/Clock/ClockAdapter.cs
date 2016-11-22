using System;
using Java.Lang;

namespace Clock
{
	public class ClockAdapter : Android.Support.V4.App.FragmentPagerAdapter
	{
		public ClockAdapter(Android.Support.V4.App.FragmentManager fm, Android.Support.V4.App.Fragment[] fragments, ICharSequence[] titles)
			: base(fm)
		{
			throw new NotImplementedException();
		}

		public override int Count
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		public override Android.Support.V4.App.Fragment GetItem(int position)
		{
			throw new NotImplementedException();
		}

		public override ICharSequence GetPageTitleFormatted(int position)
		{
			throw new NotImplementedException();
		}
	}
}