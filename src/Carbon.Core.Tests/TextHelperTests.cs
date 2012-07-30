namespace Carbon.Helpers.Tests
{
	using System;

	using NUnit.Framework;

	[TestFixture]
	public class TextHelperTests
	{
		[Test]
		public void PascalCaseToWord()
		{
			Assert.AreEqual("Orange Monster",	TextHelper.PascalCaseToWord("OrangeMonster"));
			Assert.AreEqual("big Monster",		TextHelper.PascalCaseToWord("bigMonster"));
			Assert.AreEqual("American Express", TextHelper.PascalCaseToWord("AmericanExpress"));
			Assert.AreEqual("Visa",				TextHelper.PascalCaseToWord("Visa"));

			Assert.AreEqual(
				expected: "The Quick Brown Fox Jumped Over The Lazy Dog",
				actual: TextHelper.PascalCaseToWord("TheQuickBrownFoxJumpedOverTheLazyDog")
			);
		}

		[Test]
		public void TruncateTests()
		{
			Assert.AreEqual("pancakes",	"pancakes".Truncate(20));
			Assert.AreEqual("pancakes", "pancakes".Truncate(8));
			Assert.AreEqual("pancake…",	"pancakes".Truncate(7));
			Assert.AreEqual("p…",		"pancakes".Truncate(1));
			Assert.AreEqual("p",		"pancakes".Truncate(1, ""));
		}

		[Test]
		public void ToTitleCaseTests()
		{
			Assert.AreEqual("pankcakes".ToTitleCase(), "Pankcakes");
			Assert.AreEqual("Cheesecake monster".ToTitleCase(), "Cheesecake Monster");

			Assert.AreEqual(
				expected:	"The Quick Brown Fox Jumped Over The Lazy Dog",
				actual:		"the quick brown fox jumped over the lazy dog".ToTitleCase()
			);
		}

		[Test]
		public void StripTagsTests()
		{
			Assert.AreEqual("apples", "apples".StripTags());

			Assert.AreEqual("emphasis", "<i>emphasis</i>".StripTags());

			Assert.AreEqual(
				/*expected*/ "alert('pie')",
				/*actual*/ "<script>alert('pie')</script>".StripTags()
			);

			// Assert.AreEqual(
			// 	/*expected*/ "paragraph\r\n\r\nrsecond paragraph",
			// 	/*actual*/ "<h1>first paragraph</p><p>second paragraph</p>".StripTags()
			// );

			Assert.AreEqual(
				/*expected*/ "window.location = 'redirect'",
				/*actual*/ "<script type='text/javascript'>window.location = 'redirect'</script>".StripTags()
			);
		}

		[Test]
		public void StripNonAlphaChars()
		{
			Assert.AreEqual(
				/*expected*/ "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz",
				/*actual*/ "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz`1234567890-=~!@#$%^&*()_+<>,./;'[]<>?:{}".StripNonAlphaChars()
			);
		}

		[Test]
		public void StripNonNumericChars()
		{
			Assert.AreEqual(
				/*expected*/ "1234567890",
				/*actual*/ "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz`1234567890-=~!@#$%^&*()_+<>,./;'[]<>?:{}".StripNonNumericChars()
			);
		}

		[Test]
		public void StripNonAlphaNumericChars()
		{
			Assert.AreEqual("df034", "df034".StripNonAlphaNumericChars());
			Assert.AreEqual("4934FGA", "4934FGA$%!".StripNonAlphaNumericChars());
		}

		[Test]
		public void StripScriptTagsTests()
		{
			Assert.AreEqual("bannanas".StripJavaScript(), "bannanas");
			Assert.AreEqual("<i>oranges</i>".StripJavaScript(), "<i>oranges</i>");

			// Should strip everything inside the script tags
			Assert.AreEqual("", "<script>alert('pie')</script>".StripJavaScript());
			Assert.AreEqual("", "<script type='text/javascript'>window.location = 'redirect'</script>".StripJavaScript());

		}
		[Test]
		public void StripTags()
		{
			Assert.AreEqual("alert('test'); Invalid!", "<script>alert('test');</script> <b>Invalid!</b>".StripTags());
			Assert.AreEqual("hello", "<strong>hello<br></strong>".StripTags());
			Assert.AreEqual("goodbye", @"<h1 class=""oranges"">goodbye</h1>".StripTags());
			Assert.AreEqual("<>", @"<br><span><div><><oranges>".StripTags());
			Assert.AreEqual("The goose ate the racoon < 1", "The goose ate the racoon < 1".StripTags());
		}
	}
}