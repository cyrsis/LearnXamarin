using Android.Views;
using Android.OS;

namespace Clock
{
	public class AboutFragment : Android.Support.V4.App.Fragment
	{
		public override Android.Views.View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
		{
			return inflater.Inflate(Resource.Layout.About, container, false);
		}
	}
}