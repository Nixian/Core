namespace Carbon.Helpers
{
	using System;
	using System.Globalization;

	public static class DateTimeExtensions
	{
		public static DateTime ToLocalTime(this DateTime utcTime, TimeZoneInfo destinationTimeZone)
		{
			#region Preconditions

			if (destinationTimeZone == null) 
				throw new ArgumentNullException("destinationTimeZone");

			#endregion

			return TimeZoneInfo.ConvertTimeFromUtc(utcTime, destinationTimeZone);
		}

		public static bool Within(this DateTime date, DateRange period)
		{
			return date >= period.Start && date <= period.End;
		}

		/// <summary>
		/// HTTP Date, e.g. Sun, 28 Jan 2008 12:11:37 GMT
		/// </summary>
		public static string ToRft1123(this DateTime date) 
		{
			return date.ToUniversalTime().ToString("R", CultureInfo.InvariantCulture);
		}

		public static string ToIsoString(this DateTime dt)
		{
			return ToW3UtcZ(dt);		
		}

		public static string ToIso8601(this DateTime dt, TimeUnit datePrecision, string tz = "Z")
		{
			// +00:00
			// 2011-01Z/P1M

			switch (datePrecision)
			{
				case TimeUnit.Year:			return dt.ToString("yyyy") + tz;
				case TimeUnit.Month:		return dt.ToString("yyyy-MM") + tz;
				case TimeUnit.Day:			return dt.ToString("yyyy-MM-dd") + tz;
				case TimeUnit.Hour:			return dt.ToString("yyyy-MM-ddTHH") + tz;		// 2011-01-01T01Z
				case TimeUnit.Minute:		return dt.ToString("yyyy-MM-ddTHH:mm") + tz;	// 2011-01-01T01:15Z
				case TimeUnit.Second:		return dt.ToString("yyyy-MM-ddTHH:mm:ss") + tz;
				case TimeUnit.Milisecond:	return dt.ToString("o");
			}

			return dt.ToString("yyyy-MM-ddTHH:mm:ssZ");
		}

		public static string ToW3Utc(this DateTime dt, string tz)
		{
			return ToIso8601(dt, TimeUnit.Second, tz);
		}

		public static string ToW3UtcZ(this DateTime dt)
		{
			if (dt.Millisecond > 0) 
			{
				// 2009-01-04T17:18:54.7062347Z
				return dt.ToString("o"); // (ISO 8601)
			}
			else {
				return dt.ToString("yyyy-MM-ddTHH:mm:ssZ");
			}
		}

		public static string TimeAgoInWords(this DateTime date)
		{
			switch (date.Kind)
			{
				case DateTimeKind.Unspecified:	date = DateTime.SpecifyKind(date, DateTimeKind.Utc);	break; // Assume to be Utc
				case DateTimeKind.Local:		date = date.ToUniversalTime();							break; // Convert to Utc
			}

			var ts = DateTime.UtcNow - date;

			if (ts.TotalSeconds < 1) {
				return "just now";
			}

			return ts.ToWords() + " ago";
		}

		public static DateTime ChangePrecision(this DateTime date, TimeUnit precision)
		{
			switch (precision) 
			{
				case TimeUnit.Tick:			return date;
				case TimeUnit.Milisecond:	return new DateTime(date.Year, date.Month, date.Day, date.Hour, date.Minute, date.Second, date.Millisecond, date.Kind);
				case TimeUnit.Second:		return new DateTime(date.Year, date.Month, date.Day, date.Hour, date.Minute, date.Second, date.Kind);
				case TimeUnit.Minute:		return new DateTime(date.Year, date.Month, date.Day, date.Hour, date.Minute, 0, date.Kind);
				case TimeUnit.Hour:			return new DateTime(date.Year, date.Month, date.Day, date.Hour, 0, 0, date.Kind);
				case TimeUnit.Day:			return new DateTime(date.Year, date.Month, date.Day, 0, 0, 0, date.Kind);
				case TimeUnit.Month:		return new DateTime(date.Year, date.Month, 1, 0, 0, 0, date.Kind);
				case TimeUnit.Year:			return new DateTime(date.Year, 1, 1, 0, 0, 0, date.Kind);
				default:					throw new ArgumentException("Unsupported precision: {0}.".FormatWith(precision));
			}
		}
	}
}
