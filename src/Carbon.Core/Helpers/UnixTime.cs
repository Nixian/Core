namespace Carbon
{
	using System;

	/// <summary>
	/// Unix time, or POSIX time, is a system for describing points in time, 
	/// defined as the number of seconds elapsed since midnight proleptic 
	/// Coordinated Universal Time (UTC) of January 1, 1970, not counting leap seconds.
	/// </summary>
	public static class UnixTime
	{
		public static readonly DateTime Epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

		public static Int32 GetCurrent()
		{
			var timeSinceUnixEpoch = (DateTime.UtcNow - Epoch);

			return (Int32)timeSinceUnixEpoch.TotalSeconds;
		}

		public static DateTime ConvertToDate(int secondsSince1970) {
			return Epoch.AddSeconds(secondsSince1970);
		}

		public static Int32 FromDate(DateTime date) {
			return (Int32)(date - Epoch).TotalSeconds;
		}
	}
}