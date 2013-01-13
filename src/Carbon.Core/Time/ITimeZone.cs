namespace Carbon
{
	using System;

	public interface ITimeZone
	{
		/// <summary>
		/// IANA TZ Name
		/// </summary>
		string Name { get; }

		IClock Clock { get; }

		DateTime ToLocalTime(DateTime utcTime);

		DateTime ToUtcTime(DateTime localTime);

		TimeSpan GetUtcOffset(DateTime dateTime);
	}
}