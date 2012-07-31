namespace Carbon.Security.Tests
{
	using System;

	using NUnit.Framework;

	[TestFixture]
	public class SignatureGeneratorTests
	{
		[Test]
		public void SignStringWithHMACSHA256()
		{
			string key = "secret";
			string data = "hello";

			Assert.AreEqual("iKqz7ejTrflNJquQ07r9SiCDBww7zOnAFO4EpEOEfAs=", Signature.ComputeHmacSha256(key, data).ToBase64String());
		}

		[Test]
		public void SignStringWithHMACSHA1()
		{
			string key = "secret&";
			string data = "GET&https%3A%2F%2Fwww.google.com%2Faccounts%2FOAuthGetRequestToken&oauth_callback%3Dhttp%253A%252F%252Fgooglecodesamples.com%252Foauth_playground%252Findex.php%26oauth_consumer_key%3Dexample.com%26oauth_nonce%3D8241ea3e009faaec47ed02a1fba58e09%26oauth_signature_method%3DHMAC-SHA1%26oauth_timestamp%3D1251933943%26oauth_version%3D1.0%26scope%3Dhttps%253A%252F%252Fwww.google.com%252Fanalytics%252Ffeeds%252F";

			Assert.AreEqual("l2VlqbE4MuiPZrRsZMOe8yK3C0M=", Signature.ComputeHmacSha1(key, data).ToBase64String());
		}
	}
}