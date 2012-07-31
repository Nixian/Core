namespace Carbon.Validation.Tests
{
	using NUnit.Framework;

	[TestFixture]
	public class IntegerValidationTests
	{
		[Test]
		public void ValidIntegers()
		{
			Assert.IsTrue("-1".IsValidInteger());
			Assert.IsTrue("0".IsValidInteger());
			Assert.IsTrue("1".IsValidInteger());
			Assert.IsTrue("1000000000000".IsValidInteger());
		}

		[Test]
		public void InvalidIntegers()
		{
			Assert.IsFalse("".IsValidInteger());
			Assert.IsFalse("a".IsValidInteger());
			Assert.IsFalse("4.5".IsValidInteger());
		}
	}
}
