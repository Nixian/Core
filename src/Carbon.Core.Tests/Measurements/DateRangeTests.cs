namespace Carbon.Tests
{
	using System;

	using Carbon.Helpers;

	using NUnit.Framework;

	[TestFixture]
	public class DateRangeTests
	{
		[Test]
		public void Duration_is_correctly_calculated()
		{
			var period = new DateRange(new DateTime(2008, 01, 01, 0, 0, 0, DateTimeKind.Utc), new DateTime(2008, 01, 02, 0, 0, 0, DateTimeKind.Utc));

			Assert.AreEqual(1.Day(), period.TimeSpan);
		}

		[Test]
		public void EqualityTests()
		{
			Assert.AreEqual(
				expected:	new DateRange(new DateTime(2011, 01, 01), new DateTime(2012, 01, 01)),
				actual:		new DateRange(new DateTime(2011, 01, 01), new DateTime(2012, 01, 01))
			);

			Assert.AreEqual(
				expected:	new DateRange(new DateTime(2011, 01, 01), 1.Hours()),
				actual:		new DateRange(new DateTime(2011, 01, 01), 1.Hours())
			);

			Assert.AreEqual(
				expected:	new DateRange(new DateTime(2011, 01, 01), 1.Days()),
				actual:		new DateRange(new DateTime(2011, 01, 01), new DateTime(2011, 01, 02))
			);
		}

		[Test]
		public void Not_equals()
		{
			Assert.AreNotEqual(
				expected: new DateRange(new DateTime(2011, 01, 01), new DateTime(2012, 01, 01)),
				actual: new DateRange(new DateTime(2011, 01, 02), new DateTime(2012, 01, 01))
			);

			Assert.AreNotEqual(
				expected: new DateRange(new DateTime(2011, 01, 01), new DateTime(2012, 01, 01)),
				actual: new DateRange(new DateTime(2011, 01, 02), new DateTime(2012, 02, 01))
			);
		}

		[Test]
		public void Iso8601_formatted_time_interval_is_correctly_formatted()
		{
			var timeInterval = new DateRange(new DateTime(2008, 01, 01, 12, 00, 00, DateTimeKind.Utc), new DateTime(2008, 01, 02, 12, 15, 00, DateTimeKind.Utc));

			Assert.AreEqual("2008-01-01T12:00:00Z/P1DT15M", timeInterval.ToIsoDateTimeDurationInterval());
		}


		[Test]
		public void Iso8601_formatted_time_interval_is_correctly_formatted_2()
		{
			var timeInterval = new DateRange(new DateTime(2008, 01, 01, 5, 18, 15, DateTimeKind.Utc), 5.Minutes());

			Assert.AreEqual("2008-01-01T05:18:15Z/PT5M", timeInterval.ToIsoDateTimeDurationInterval());
		}

		[Test]
		public void Date_range_from_start_and_duration_is_correctly_constructed()
		{
			// Jan 1st, 2010 @ 12:00 UTC
			var start = new DateTime(2010, 01, 01, 12, 00, 00, DateTimeKind.Utc);

			var period = new DateRange(start, 1.Hours());

			Assert.AreEqual(period.Start, start);
			Assert.AreEqual(period.End, start + 1.Hours());
			Assert.AreEqual(DateTimeKind.Utc, period.End.Kind);
			Assert.AreEqual(1.Hours(), period.TimeSpan);
		}
	}
}
