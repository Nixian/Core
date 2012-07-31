namespace Carbon.Tests
{
	using System;

	using Carbon.Helpers;

	using NUnit.Framework;

	[TestFixture]
	public class IntervalTests
	{
		[Test]
		public void IntervalFromDurations()
		{
			// Days
			Assert.AreEqual(new DateTime(2008, 01, 08), Interval.FromIsoDuration("P7D").CalculateNext(new DateTime(2008, 01, 01)));

			// Months
			Assert.AreEqual(new DateTime(2008, 02, 01), Interval.FromIsoDuration("P1M").CalculateNext(new DateTime(2008, 01, 01)));
			Assert.AreEqual(new DateTime(2008, 04, 01), Interval.FromIsoDuration("P2M").CalculateNext(new DateTime(2008, 02, 01)));
			Assert.AreEqual(new DateTime(2008, 08, 11), Interval.FromIsoDuration("P5M").CalculateNext(new DateTime(2008, 03, 11)));

			Assert.AreEqual(new DateTime(2009, 01, 12), Interval.FromIsoDuration("P1M").CalculateNext(new DateTime(2008, 12, 12)));


			// Years
			Assert.AreEqual(new DateTime(2018, 01, 01), Interval.FromIsoDuration("P10Y").CalculateNext(new DateTime(2008, 01, 01)));
			Assert.AreEqual(new DateTime(2009, 01, 01), Interval.FromIsoDuration("P1Y").CalculateNext(new DateTime(2008, 01, 01)));
			Assert.AreEqual(new DateTime(2009, 01, 01), Interval.FromIsoDuration("P1Y").CalculateNext(new DateTime(2008, 01, 01)));
			Assert.AreEqual(new DateTime(2009, 01, 01), Interval.FromIsoDuration("P1Y").CalculateNext(new DateTime(2008, 01, 01)));
			Assert.AreEqual(new DateTime(2010, 01, 01), Interval.FromIsoDuration("P2Y").CalculateNext(new DateTime(2008, 01, 01)));

		}
		[Test]
		public void OneMonthInterval()
		{
			var interval = new MonthlyInterval(1);

			Assert.AreEqual(new DateTime(2008, 02, 01), interval.CalculateNext(new DateTime(2008, 01, 01)));
			Assert.AreEqual(new DateTime(2008, 03, 01), interval.CalculateNext(new DateTime(2008, 02, 01)));
			Assert.AreEqual(new DateTime(2008, 04, 01), interval.CalculateNext(new DateTime(2008, 03, 01)));
			Assert.AreEqual(new DateTime(2008, 05, 01), interval.CalculateNext(new DateTime(2008, 04, 01)));

			Assert.AreEqual(new DateTime(2009, 01, 12), interval.CalculateNext(new DateTime(2008, 12, 12)));
		}

		[Test]
		public void TwoMonthInterval()
		{
			var interval = new MonthlyInterval(2);

			Assert.AreEqual(new DateTime(2008, 03, 01), interval.CalculateNext(new DateTime(2008, 01, 01)));
			Assert.AreEqual(new DateTime(2008, 04, 18), interval.CalculateNext(new DateTime(2008, 02, 18)));
			Assert.AreEqual(new DateTime(2008, 05, 01), interval.CalculateNext(new DateTime(2008, 03, 01)));
			Assert.AreEqual(new DateTime(2008, 06, 01), interval.CalculateNext(new DateTime(2008, 04, 01)));

			Assert.AreEqual(new DateTime(2009, 02, 12), interval.CalculateNext(new DateTime(2008, 12, 12)));
		}

		[Test]
		public void OneYearInterval()
		{
			var interval = new YearlyInterval(1);

			Assert.AreEqual(new DateTime(2009, 01, 01), interval.CalculateNext(new DateTime(2008, 01, 01)));
		}

		[Test]
		public void DailyCalculations()
		{
			var interval = Interval.Daily();

			Assert.AreEqual(new DateTime(2008, 1, 2), interval.CalculateNext(new DateTime(2008, 1, 1)));
			Assert.AreEqual(new DateTime(2008, 1, 3), interval.CalculateNext(new DateTime(2008, 1, 2)));

			Assert.AreEqual(new DateTime(2010, 03, 01), interval.CalculateNext(new DateTime(2010, 02, 28)));
		}

		[Test]
		public void SecondCalculations()
		{
			var interval = new FixedInterval(2.Seconds());

			Assert.AreEqual(new DateTime(2008, 1, 1, 00, 00, 02), interval.CalculateNext(new DateTime(2008, 1, 1, 00, 00, 00)));
			Assert.AreEqual(new DateTime(2008, 1, 1, 00, 00, 04), interval.CalculateNext(new DateTime(2008, 1, 1, 00, 00, 02)));
			Assert.AreEqual(new DateTime(2008, 1, 1, 00, 00, 06), interval.CalculateNext(new DateTime(2008, 1, 1, 00, 00, 04)));

			Assert.AreEqual(new DateTime(2008, 1, 1, 00, 01, 01), interval.CalculateNext(new DateTime(2008, 1, 1, 00, 00, 59)));
		}
	}
}