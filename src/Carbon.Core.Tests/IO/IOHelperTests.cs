namespace Carbon.Helpers.Tests
{
	using System;

	using NUnit.Framework;

	[TestFixture]
	public class IOHelperTests
	{
		[Test]
		public void FormatBytes()
		{
			Assert.AreEqual("1.00 KB", IOHelper.FormatBytes(IOHelper.BytesInKilobyte));
			Assert.AreEqual("2.00 KB", IOHelper.FormatBytes(IOHelper.BytesInKilobyte * 2));
			Assert.AreEqual("1.00 MB", IOHelper.FormatBytes(IOHelper.BytesInMegabyte));
			Assert.AreEqual("1.00 GB", IOHelper.FormatBytes(IOHelper.BytesInGigabyte));
			Assert.AreEqual("1.00 TB", IOHelper.FormatBytes(IOHelper.BytesInTerabyte));
			Assert.AreEqual("1.00 PB", IOHelper.FormatBytes(IOHelper.BytesInPetabyte));

			Assert.AreEqual("895 TB", IOHelper.FormatBytes(984529829849028));
			Assert.AreEqual("8.95 TB", IOHelper.FormatBytes(9845299849028));
			Assert.AreEqual("17.2 GB", IOHelper.FormatBytes(18452998498));

			Assert.AreEqual("5.44 GB", IOHelper.FormatBytes(5845284028));
			Assert.AreEqual("36.5 MB", IOHelper.FormatBytes(38295898));
		}
	}
}