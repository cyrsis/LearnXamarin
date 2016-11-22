using Java.Lang;

namespace Clock
{
	//
	// FragmentPagerAdapter is for a small, fixed number of tabs like the Clock UI
	//
	public class ClockAdapter : Android.Support.V4.App.FragmentPagerAdapter
	{
		//
		// The collection of Fragments are the "pages" that the ViewPager will display
		//
		Android.Support.V4.App.Fragment[] fragments;

		//
		// The titles are used on the tabs displayed by PagerTabString
		//
		ICharSequence[] titles;

		//
		// The ViewPager will handle all the Fragment transactions, but it needs a FragmentManager to do that
		//
		public ClockAdapter(Android.Support.V4.App.FragmentManager fm, Android.Support.V4.App.Fragment[] fragments, ICharSequence[] titles)
			: base(fm)
		{
			this.fragments = fragments;
			this.titles    = titles;
		}

		public override int Count
		{
			get { return fragments.Length; }
		}

		public override Android.Support.V4.App.Fragment GetItem(int position)
		{
			return fragments[position];
		}

		//
		// Titles must use Java.Lang.ICharSequence
		//
		public override ICharSequence GetPageTitleFormatted(int position)
		{
			return titles[position];
		}
	}
}