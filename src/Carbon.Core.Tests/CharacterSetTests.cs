namespace Carbon.Helpers.Tests
{
	using System.Linq;

	using NUnit.Framework;

	[TestFixture]
	public class CharacterSetTests
	{
		[Test]
		public void UrlSafeCharacterSet()
		{
			var set = CharacterSet.UrlSafe;
			Assert.IsTrue("abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-_.~".Select(set.Contains).All(v => v == true));

			Assert.IsFalse(set.Contains('あ'));
		}
	}
}
