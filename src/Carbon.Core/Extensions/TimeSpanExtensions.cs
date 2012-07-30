namespace Carbon.Helpers
{
	using System;

	public static class TimeSpanExtensions
	{
		public static Duration ToDuration(this TimeSpan ts)
		{
			return Duration.FromTimeSpan(ts);
		}

		public static string ToWords(this TimeSpan ts)
		{
			if (ts.TotalSeconds < 1) 
			{
				return "{0} seconds".FormatWith(ts.TotalSeconds.ToString("0.0"));
			}

			if (ts.Days == 0)
			{
				if (ts.Hours == 0)
				{
					if (ts.Minutes == 0) 
					{
						return "{0} second{1}".FormatWith(ts.Seconds, ts.Seconds > 1 ? "s" : "");
					}
					else 
					{
						return "{0} minute{1}".FormatWith(ts.Minutes, ts.Minutes > 1 ? "s" : "");
					}
				}
				else
				{
					return "{0} hour{1}".FormatWith(ts.Hours, ts.Hours > 1 ? "s" : "");
				}
			}
			else if (ts.Days < 30) 
			{
				return "{0} day{1}".FormatWith(ts.Days, ts.Days > 1 ? "s" : "");
			}
			else if (ts.Days < 365) 
			{
				string s = (ts.Days / 30 == 1) ? "" : "s";

				return "about {0} month{1}".FormatWith(ts.Days / 30, s);
			}
			else 
			{
				string s = (ts.Days / 365 == 1) ? "" : "s";

				return "about {0} year{1}".FormatWith(ts.Days / 365, s);
			}
		}
	}
}
