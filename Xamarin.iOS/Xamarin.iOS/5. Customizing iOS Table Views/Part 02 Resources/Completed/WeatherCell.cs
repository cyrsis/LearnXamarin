using System;
using UIKit;
using CoreGraphics;

namespace WeatherApp
{
	public class WeatherCell : UITableViewCell
	{
		UIImageView imgWeather;
		UILabel lblCity;
		UILabel lblHigh;
		UILabel lblLow;

		public WeatherCell (IntPtr ptr) : base (ptr)
		{
			var cellFont = UIFont.SystemFontOfSize(14);
			var cellTextColor1 = UIColor.FromRGB (59, 102, 136);
			var cellTextColor2 = UIColor.FromRGB (119, 180, 229);

			imgWeather = new UIImageView ();
			lblCity = new UILabel () { Font = cellFont, TextColor = cellTextColor1 };
			lblHigh = new UILabel () { Font = cellFont, TextColor = cellTextColor2, TextAlignment = UITextAlignment.Right };
			lblLow = new UILabel () { Font = cellFont, TextColor = cellTextColor1, TextAlignment = UITextAlignment.Right };

			ContentView.Add (imgWeather);
			ContentView.Add (lblCity);
			ContentView.Add (lblHigh);
			ContentView.Add (lblLow);
		}

		public override void LayoutSubviews ()
		{
			base.LayoutSubviews ();

			var width = ContentView.Frame.Width;

			imgWeather.Frame = new CGRect (0, 0, 30, 30);
			imgWeather.Center = ContentView.Center;

			lblCity.Frame = new CGRect (20, 7, 100, 30);
			lblLow.Frame = new CGRect (width - 50, 7, 30, 30);
			lblHigh.Frame = new CGRect (lblLow.Frame.Left - 30, 7, 30, 30);

		}

		public void UpdateData (Weather weather)
		{
			imgWeather.Image = UIImage.FromBundle(weather.CurrentConditions.ToString() + ".png");

			lblCity.Text = weather.City;
			lblHigh.Text = String.Format ("{0}", weather.High);
			lblLow.Text = String.Format ("{0}", weather.Low);
		}
	}
}

