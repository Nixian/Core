namespace Carbon.Validation.Tests
{
	using NUnit.Framework;

	[TestFixture]
	public class EmailAddressValidationTests
	{
		[Test]
		public void EmailAddressesAreValid()
		{
			Assert.IsTrue("jason.nelson@gmail.com".IsValidEmailAddress());
			Assert.IsTrue("mgorycki+carbonmade.com@gmail.com".IsValidEmailAddress());

			Assert.IsFalse("".IsValidEmailAddress());
			Assert.IsFalse("@".IsValidEmailAddress());
			Assert.IsFalse("jason@".IsValidEmailAddress());
		}
	}
}