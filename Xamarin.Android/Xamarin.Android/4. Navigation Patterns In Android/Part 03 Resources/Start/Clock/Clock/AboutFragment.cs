using Android.Views;
using Android.OS;
using Android.App;

namespace Clock
{
	public class AboutFragment : Fragment
	{
		public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
		{
			return inflater.Inflate(Resource.Layout.About, container, false);
		}
	}
}