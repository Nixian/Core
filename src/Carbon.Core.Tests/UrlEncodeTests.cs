namespace Carbon.Helpers.Tests
{
	using System;

	using NUnit.Framework;

	[TestFixture]
	public class UrlEncodeTests
	{
		[Test]
		public void UrlEncode()
		{
			// unreserved  = alphanum | mark

			//  mark = "-" | "_" | "." | "!" | "~" | "*" | "'" | "(" | ")"

			// Alphanumeric
			Assert.AreEqual(
				/*expected*/ "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789",
				/*actual*/ "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789".UrlEncode()
			);

			Console.WriteLine("~".UrlEncode());
			// Space
			// Assert.AreEqual("%20", " ".UrlEncode()); = +

			// ' is encoded as %27 in .NET 4.0
			Assert.AreEqual("-_.!*()", "-_.!*()".UrlEncode()); // excluded: ~
		}

		[Test]
		public void UrlEncodeX2Tests()
		{
			// Alphanumeric
			Assert.AreEqual(
				/*expected*/ "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789",
				/*actual*/ "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789".UrlEncode()
			);

			Assert.AreEqual("-._~", "-._~".UrlEncodeX2());

			Assert.AreEqual("%3C", "<".UrlEncodeX2());
			Assert.AreEqual("%25", "%".UrlEncodeX2());
			Assert.AreEqual("%26", "&".UrlEncodeX2());
			Assert.AreEqual("%3D", "=".UrlEncodeX2());
			Assert.AreEqual("%2A", "*".UrlEncodeX2());

			Assert.AreEqual("%2B", "+".UrlEncodeX2());
			Assert.AreEqual("%20", " ".UrlEncodeX2());


			Assert.AreEqual("%26%3D%2A", "&=*".UrlEncodeX2());

			// Unicode tests

			Assert.AreEqual("%E3%81%82", "あ".UrlEncodeX2());
			Assert.AreEqual("%C3%A9", "é".UrlEncodeX2());

			Assert.AreEqual("%0A", "\u000A".UrlEncodeX2());
			Assert.AreEqual("%20", "\u0020".UrlEncodeX2());
			Assert.AreEqual("%7F", "\u007F".UrlEncodeX2());
			Assert.AreEqual("%C2%80", "\u0080".UrlEncodeX2());
			Assert.AreEqual("%E3%80%81", "\u3001".UrlEncodeX2());
		}
	}
}
