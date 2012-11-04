namespace Carbon.Helpers.Tests
{
	using System;

	using NUnit.Framework;

	[TestFixture]
	public class DateTimeExtensions
	{
		[Test]
		public void ChangeDatePrecisionTests()
		{
			Assert.AreEqual(new DateTime(2011, 01, 01), new DateTime(2011, 02, 11, 15, 12, 11).ChangePrecision(TimeUnit.Year));
			Assert.AreEqual(new DateTime(2011, 02, 01), new DateTime(2011, 02, 11, 15, 12, 11).ChangePrecision(TimeUnit.Month));
			Assert.AreEqual(new DateTime(2011, 02, 11), new DateTime(2011, 02, 11, 15, 12, 11).ChangePrecision(TimeUnit.Day));
			// Assert.AreEqual(new DateTime(2011, 01, 01), new DateTime(2011, 02, 11, 15, 12, 11).ChangePrecision(TimeUnit.Day));
			// Assert.AreEqual(new DateTime(2011, 01, 01), new DateTime(2011, 02, 11, 15, 12, 11).ChangePrecision(TimeUnit.Day));
			// Assert.AreEqual(new DateTime(2011, 01, 01), new DateTime(2011, 02, 11, 15, 12, 11).ChangePrecision(TimeUnit.Day));
		}
	}
}