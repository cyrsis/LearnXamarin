using Android.Widget;
using Android.Support.V7.Widget;
using Android.Views;
using System;

namespace Dining
{
	public class RestaurantViewHolder : RecyclerView.ViewHolder
	{
		Action<int> listener;

		public TextView  Name   { get; set; }
		public RatingBar Rating { get; set; }

		public RestaurantViewHolder(View itemView, Action<int> listener)
			: base(itemView)
		{
			Name   = itemView.FindViewById<TextView >(Resource.Id.nameTextView);
			Rating = itemView.FindViewById<RatingBar>(Resource.Id.ratingBar);

			this.listener = listener;

			itemView.Click += OnClick;
		}

		void OnClick(object sender, EventArgs e)
		{
			int position = base.AdapterPosition;

			if (position == RecyclerView.NoPosition)
				return;

			listener(position);
		}
	}
}