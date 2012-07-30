namespace Carbon.Helpers.Tests
{
	using System;

	using NUnit.Framework;

	[TestFixture]
	public class StringExtensionsTest
	{
		[Test]
		public void SplitIntoSegmentsTest()
		{
			var text = "hello everyone";
			var segments = text.SplitIntoSegments(5);

			Assert.AreEqual(3, segments.Length);
			Assert.AreEqual("hello", segments[0]);
			Assert.AreEqual(" ever", segments[1]);
			Assert.AreEqual("yone", segments[2]);

			text = "012345";
			segments = text.SplitIntoSegments(1);

			Assert.AreEqual(6, segments.Length);
			Assert.AreEqual("0", segments[0]);
			Assert.AreEqual("1", segments[1]);
			Assert.AreEqual("2", segments[2]);
			Assert.AreEqual("3", segments[3]);
			Assert.AreEqual("4", segments[4]);
			Assert.AreEqual("5", segments[5]);

			text = "onethetwo1";
			segments = text.SplitIntoSegments(3);

			Assert.AreEqual(4, segments.Length);
			Assert.AreEqual("one", segments[0]);
			Assert.AreEqual("the", segments[1]);
			Assert.AreEqual("two", segments[2]);
			Assert.AreEqual("1", segments[3]);
		}

		[Test]
		public void ToUriTests()
		{
			Assert.AreEqual(new Uri("http://www.google.com/"), "www.google.com".ToUri());

			Assert.AreEqual(
				/*expected*/ new Uri("https://billing.carbonmade.com/"),
				/*actual*/ "https://billing.carbonmade.com".ToUri()
			);

			Assert.AreEqual(
				/*expected*/ new Uri("http://engadget.com/"),
				/*actual*/ "engadget.com".ToUri()
			);

			Assert.IsNull("".ToUri());
		}

		[Test]
		public void ToDecimalTests()
		{
			Assert.AreEqual(0m, "0".ToDecimal());
			Assert.AreEqual(1.94m, "1.94".ToDecimal());
			Assert.AreEqual(-5.1m, "-5.1".ToDecimal());
			Assert.AreEqual(100m, "100".ToDecimal());
			Assert.AreEqual(0m, "orange".ToDecimal());
			Assert.AreEqual(0m, "".ToDecimal());
		}

		[Test]
		public void ToDoubleTests()
		{
			Assert.AreEqual(0d, "0".ToDouble());
			Assert.AreEqual(1.94d, "1.94".ToDouble());
			Assert.AreEqual(-5.1d, "-5.1".ToDouble());
			Assert.AreEqual(100d, "100".ToDouble());
			Assert.AreEqual(0d, "orange".ToDouble());
			Assert.AreEqual(0d, "".ToDouble());
		}

		[Test]
		public void ToFloatTests()
		{
			Assert.AreEqual(0f, "0".ToFloat());
			Assert.AreEqual(1.94f, "1.94".ToFloat());
			Assert.AreEqual(-5.1f, "-5.1".ToFloat());
			Assert.AreEqual(100f, "100".ToFloat());
			Assert.AreEqual(0f, "orange".ToInt());
			Assert.AreEqual(0f, "".ToInt());
		}

		[Test]
		public void ToIntTests()
		{
			string n = null;

			Assert.AreEqual(0, "0".ToInt());
			Assert.AreEqual(1, "1".ToInt());
			Assert.AreEqual(-5, "-5".ToInt());
			Assert.AreEqual(100, "100".ToInt());
			Assert.AreEqual(0, "orange".ToInt());
			Assert.AreEqual(0, "".ToInt());
			Assert.AreEqual(0, n.ToInt());
		}

		[Test]
		public void ToNullableIntTests()
		{
			Assert.AreEqual(0, "0".ToNullableInt());
			Assert.AreEqual(1, "1".ToNullableInt());
			Assert.AreEqual(-5, "-5".ToNullableInt());
			Assert.AreEqual(100, "100".ToNullableInt());
			Assert.AreEqual(null, "orange".ToNullableInt());
			Assert.AreEqual(null, "".ToNullableInt());
		}

		[Test]
		public void FormatWithTests()
		{
			Assert.AreEqual("Invoice #1", "Invoice #{0}".FormatWith(1));
			Assert.AreEqual("2005-2006", "{0}-{1}".FormatWith(2005, 2006));
		}

		[Test]
		public void ToEnumTests()
		{
			Assert.AreEqual(Alpha.A, "A".ToEnum<Alpha>());
			Assert.AreEqual(Alpha.B, "B".ToEnum<Alpha>());
			Assert.AreEqual(Alpha.C, "C".ToEnum<Alpha>());

			Assert.AreEqual(Alpha.A, "a".ToEnum<Alpha>(true));
			Assert.AreEqual(Alpha.B, "b".ToEnum<Alpha>(true));
			Assert.AreEqual(Alpha.C, "c".ToEnum<Alpha>(true));

			Assert.AreEqual(0, (int)"0".ToEnum<Alpha>());
			Assert.AreEqual(1, (int)"1".ToEnum<Alpha>());
			Assert.AreEqual(2, (int)"2".ToEnum<Alpha>());
		}

		public enum Alpha
		{
			A,
			B,
			C
		}
	}
}