using System;
using System.Collections.ObjectModel;

namespace FiniteLengthTasks
{
	/// <summary>
	/// Logger helper. Logs all output to the console but also stores it into an observable collection.
	/// </summary>
	public static class Logger
	{
		/// <summary>
		/// Logged data.
		/// </summary>
		public static ObservableCollection<string> LoggedData = new ObservableCollection<string>();

		/// <summary>
		/// Logs a string.
		/// </summary>
		/// <param name="s">string</param>
		/// <param name="args">Arguments</param>
		public static void Log(string s, params object[] args)
		{
			s = "[" + DateTime.Now.ToString("HH:mm:ss.fff") + "] " + s;
			if (args != null)
			{
				s = string.Format (s, args);
			}

			Console.WriteLine (s);
			LoggedData.Add (s);
		}

		/// <summary>
		/// Logs a string.
		/// </summary>
		/// <param name="s">string</param>
		public static void Log(string s)
		{
			Log (s, null);
		}
	}
}

