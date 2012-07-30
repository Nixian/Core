namespace Carbon.Validation.Tests
{
	using System;
	using NUnit.Framework;

	using Carbon.Helpers;

	[TestFixture]
	public class NumberValidationTests
	{
		[Test]
		public void Numbers()
		{
			Assert.IsTrue("1".IsNumeric());

			Console.WriteLine(GetNumber("asdfasfd3234"));
			Console.WriteLine(GetNumber("asdfasdf34234234sdf"));
		}

		public static string GetNumber(string text)
		{
			var sbNumber = "";

			foreach (var c in text)
			{
				if (c.IsNumber())
				{
					sbNumber += c;
				}
			}

			return sbNumber;
		}
	}
}