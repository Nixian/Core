namespace Carbon.Security.Tests
{
	using System;
	using System.Linq;

	using Carbon.Data;
	using Carbon.Helpers;
	using Carbon.Models;

	using NUnit.Framework;

	[TestFixture]
	public class SantizerTests
	{
		[Test]
		public void Test()
		{
			var html = @"<a target=""_blank"" href=""http://casinospam.com"">SPAM</a>";

			var result = Sanitizer.AddNoFollows(html);

			Assert.AreEqual(@"<a target=""_blank"" href=""http://casinospam.com"" rel=""nofollow"">SPAM</a>", result);
		}

		[Test]
		public void Entity_with_no_sanitizers_reports_no_sanitizers()
		{
			var properties = Sanitizer.GetPropertiesNeedingSanitation(typeof(Word));

			Assert.AreEqual(0, properties.Count());
		}

		[Test]
		public void BasicEntity()
		{
			var post = new Post
			{
				Title = "<script>alert('test');</script> <b>Invalid!</b>",
				Body = "<b>oranges</b>"
			};

			var properties = Sanitizer.GetPropertiesNeedingSanitation(post.GetType());

			// Make sure there are three properties needing santization (title and body)
			Assert.AreEqual(2, properties.Count());

			Sanitizer.Sanitize(post);

			// Ensure it striped out the script and HTML tags in the post title
			Assert.AreEqual(" Invalid!", post.Title);

			// Make sure the body is the same (HTML is allowed)
			Assert.AreEqual("<b>oranges</b>", post.Body);
		}

		[Test]
		public void InhertedPropertiesResource()
		{
			var post = new Post {
				Title = "<script>alert('test');</script> <b>Invalid!</b>",
				Body = "<b>oranges</b>"
			};

			var properties = Sanitizer.GetPropertiesNeedingSanitation(post.GetType());

			// Make sure there are three properties needing santization (title and body and category)
			Assert.AreEqual(2, properties.Count());

			Sanitizer.Sanitize(post);

			// Ensure it striped out the script and HTML tags in the post title
			Assert.AreEqual(" Invalid!", post.Title);

			// Make sure the body is the same (HTML is allowed)
			Assert.AreEqual("<b>oranges</b>", post.Body);
		}
	}

	internal class Post : IAuthorizable
	{
		public int Id { get; set; }

		[Sanitize]
		public string Title { get; set; }

		[Sanitize(AllowHtml = true)]
		public string Body { get; set; }

		public IContainer Owner { get; set; }
	}

	internal class Word
	{
		public int Id { get; set; }

		public string Name { get; set; }
	}
}