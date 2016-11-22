using Android.Widget;
using Android.Support.V7.Widget;
using Android.Views;

namespace Dining
{
	public class RestaurantViewHolder : RecyclerView.ViewHolder
	{
		public TextView  Name   { get; set; }
		public RatingBar Rating { get; set; }

		public RestaurantViewHolder(View itemView)
			: base(itemView)
		{
			Name   = itemView.FindViewById<TextView >(Resource.Id.nameTextView);
			Rating = itemView.FindViewById<RatingBar>(Resource.Id.ratingBar);
		}
	}
}