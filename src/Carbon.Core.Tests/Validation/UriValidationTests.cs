namespace Carbon.Validation.Tests
{
	using NUnit.Framework;

	using Carbon.Helpers;

	[TestFixture]
	public class UriValidationTests
	{
		[Test]
		public void ValidUris()
		{
			Assert.IsTrue("http://www.google.com".IsValidUri());
			Assert.IsTrue("http://my.carbonmade.com/projects/".IsValidUri());
		}

		[Test]
		public void InvalidUris()
		{
			Assert.IsFalse("www.google.com".IsValidUri());
			Assert.IsFalse("/portfolios/".IsValidUri());
			Assert.IsFalse("/portfolios/fashion.json".IsValidUri());
			Assert.IsFalse("4.5".IsValidUri());
			Assert.IsFalse("test".IsValidUri());
			Assert.IsFalse("".IsValidUri());
		}
	}
}
