namespace Carbon.Validation.Tests
{
	using NUnit.Framework;

	[TestFixture]
	public class StringValidationTests
	{
		[Test]
		public void LettersAndNumbers()
		{
			Assert.IsTrue("1234567890".ContainsOnlyLettersOrDigits());
			Assert.IsTrue("redfishbluefish".ContainsOnlyLettersOrDigits());

			// Accents
			Assert.IsTrue("áéíóú".ContainsOnlyLettersOrDigits());
			Assert.IsTrue("ÁÉÍÓÚ".ContainsOnlyLettersOrDigits());
			Assert.IsTrue("äöÜÖë".ContainsOnlyLettersOrDigits());
			Assert.IsTrue("àèÙÒ".ContainsOnlyLettersOrDigits());
			Assert.IsTrue("ãñÑÕ".ContainsOnlyLettersOrDigits());
			Assert.IsTrue("âôÊÎ".ContainsOnlyLettersOrDigits());

			Assert.IsFalse("$5".ContainsOnlyLettersOrDigits());
			Assert.IsFalse("a-b".ContainsOnlyLettersOrDigits());
			Assert.IsFalse("a_b".ContainsOnlyLettersOrDigits());
			Assert.IsFalse("$%@#$%#$".ContainsOnlyLettersOrDigits());
		}

		[Test]
		public void AreAlphanumeric()
		{
			Assert.IsTrue("abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWZYZ0123456789".IsAlphaNumeric());

			Assert.IsFalse("a-b".IsAlphaNumeric());
			Assert.IsFalse("a_b".IsAlphaNumeric());
			Assert.IsFalse("a.b".IsAlphaNumeric());
			Assert.IsFalse("$%@#$%#$".IsAlphaNumeric());
		}

		[Test]
		public void AreNumeric()
		{
			Assert.IsTrue("1234567890".IsNumeric());

			Assert.IsFalse("$5".IsNumeric());
			Assert.IsFalse("a-b".IsNumeric());
			Assert.IsFalse("a_b".IsNumeric());
			Assert.IsFalse("$%@#$%#$".IsNumeric());
		}
	}
}