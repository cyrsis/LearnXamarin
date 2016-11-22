using System;
using System.Collections.Generic;

namespace Dining
{
	public class Restaurant 
	{
		public Restaurant(string name, float rating)
		{
			Name   = name;
			Rating = rating;
		}

		public string Name   { get; set; }
		public float  Rating { get; set; }
	}

	public static class SampleData
	{
		public static List<Restaurant> GetRestaurants()
		{
			var restaurants = new List<Restaurant>();

			restaurants.Add(new Restaurant("Joe's Coffee Shop",  3.5F));
			restaurants.Add(new Restaurant("Bakehouse Cakes",    2.0F));
			restaurants.Add(new Restaurant("Silver Spoon Diner", 2.5F));
			restaurants.Add(new Restaurant("Pasta Connection",   4.0F));
			restaurants.Add(new Restaurant("Main Grill",         1.0F));
			restaurants.Add(new Restaurant("Pizza Central",      2.0F));
			restaurants.Add(new Restaurant("Taverna on Main",    5.0F));
			restaurants.Add(new Restaurant("Cow & Pig",          3.0F));

			return restaurants;
		}
	}
}