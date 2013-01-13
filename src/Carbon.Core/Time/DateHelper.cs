namespace Carbon.Helpers
{
	using System;

	using Carbon;

	// Epoch: An instant in time that is arbitrarily selected as a point of reference.

	public static class DateHelper
	{
		// DateTimeFormatInfo.CurrentInfo.MonthNames
		public static readonly string[] MonthNames = {
			"January", "February", "March", "April", "May", "June", "July", 
			"August", "September", "October", "November", "December" 
		};

		public static readonly string[] MonthNamesAbbreviated = { 
			"Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec" 
		};

		public static DateTime GetLastDayOfMonth(int year, int month)
		{
			return new DateTime(year, month, DateTime.DaysInMonth(year, month));
		}

		/// <summary>
		/// Converts a date to date+time+offset for the provided time zone
		/// </summary>
		public static DateTimeOffset ToDateTimeOffset(this DateTime dateTime, ITimeZone timeZone)
		{
			// HACK
			if (dateTime.Kind != DateTimeKind.Unspecified)
			{
				dateTime = DateTime.SpecifyKind(dateTime, DateTimeKind.Unspecified);
			}

			var utcOffset = timeZone.GetUtcOffset(dateTime);

			return new DateTimeOffset(dateTime, utcOffset);
		}

		public static DateTime GetNextAlignedDate(DateTime date, TimeSpan interval)
		{
			#region Preconditions

			if (60 % interval.TotalMinutes != 0)
				throw new Exception("Interval minute must be a factor of 60");

			#endregion

			// e.g. 5 minute intervals achored with the begining of the hour

			// 4:00 - 4:05

			// 00, 05, 10, 15, 20, 25, 30, 35, 40, 45, 50, 55

			int minutes = (date.Minute / (int)interval.TotalMinutes) * (int)interval.TotalMinutes;

			if (date.Minute % interval.TotalMinutes > 0 || date.Second > 0 || date.Millisecond > 0)
			{
				minutes += (int)interval.TotalMinutes;
			}

			return date.ChangePrecision(TimeUnit.Hour).AddMinutes(minutes);
		}

		public static DateTime? DateFromMonthAndYear(string year, string month)
		{
			DateTime? expirationDate = null;

			try 
			{
				expirationDate = new DateTime(year.ToInt(), month.ToInt(), 1);
			}
			catch { }

			return expirationDate;
		}

		/*
        public static DateTime AddMonths(DateTime date, int monthsToAdd, MonthlyOverflowRule overflowRule)
        {
            int year = date.Year;
            int month = date.Month + months;
            int day = date.Day;

			// If the day in the next month doesn't exist, use the first day of the following month
			int daysInNextMonth = Thread.CurrentThread.CurrentCulture.Calendar.GetDaysInMonth(year, month);

			if (day > daysInNextMonth) {
				month += 1;
				day = 1;
			}

            if (month > 12) {
                month = (month - 12);
                year = year + 1;
            }

            return new DateTime(year, month, day);
        }
		*/
	}

	public enum MonthlyOverflowRule
	{
		ClipBack,		// Apr 31 becomes Apr 30
		Drop,			// Apr 31 is ignored
		OverlapForward	// Apr 31 becomes May 1
	}
}