namespace Carbon.Helpers.Tests
{
	using System;
	using System.IO;

	using NUnit.Framework;

	[TestFixture]
	public class QuotedPrintableTests
	{
		[Test]
		public void DecodeTests()
		{
			Assert.AreEqual("Dia das Mães-Aya.jpg", QuotedPrintable.Decode("=?UTF-8?Q?Dia_das_M=C3=A3es-Aya.jpg?="));
		}
	}
}