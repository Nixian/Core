namespace Carbon.Tests
{
	using System;

	using Carbon.Helpers;

	using NUnit.Framework;

	[TestFixture]
	public class DurationTests
	{
		[Test]
		public void Parse()
		{
			Assert.AreEqual("P7D", Duration.Parse("P7D").ToString());
			Assert.AreEqual("P1M", Duration.Parse("P1M").ToString());
			Assert.AreEqual("P1Y", Duration.Parse("P1Y").ToString());

			Assert.AreEqual(7, Duration.Parse("P7D").Days);
			Assert.AreEqual(1, Duration.Parse("P1M").Months);
			Assert.AreEqual(1, Duration.Parse("P1Y").Years);

			Assert.AreEqual("P5D", Duration.Parse("P5D").ToString());
			Assert.AreEqual("PT37M", Duration.Parse("PT37M").ToString());

			var duration = Duration.Parse("P5Y9M3W7DT7H55M30S");

			Assert.AreEqual("P5Y9M3W7DT7H55M30S", duration.ToString());

			Assert.AreEqual(5, duration.Years);
			Assert.AreEqual(3, duration.Weeks);
			Assert.AreEqual(9, duration.Months);
			Assert.AreEqual(7, duration.Days);
			Assert.AreEqual(7, duration.Hours);
			Assert.AreEqual(55, duration.Minutes);
			Assert.AreEqual(30, duration.Seconds);

			// Years
			Assert.AreEqual(3, Duration.Parse("P3Y").Years);
		}

		[Test]
		public void ToISO8601()
		{
			Assert.AreEqual("P5D",			5.Days().ToDuration().ToString());
			Assert.AreEqual("PT5H",			5.Hours().ToDuration().ToString());
			Assert.AreEqual("PT5M",			5.Minutes().ToDuration().ToString());
			Assert.AreEqual("PT2H30M5S",	TimeSpan.FromHours(2.5).Add(5.Seconds()).ToDuration().ToString());
			Assert.AreEqual("PT0.5S",		500.Milliseconds().ToDuration().ToString());
		}
	}
}