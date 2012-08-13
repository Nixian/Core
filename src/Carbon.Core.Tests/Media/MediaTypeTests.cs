namespace Carbon.Media.Tests
{
	using System;

	using Carbon.Helpers;

	using NUnit.Framework;

	[TestFixture]
	public class MediaTypeTests
	{
		[Test]
		public void IntMappingTests()
		{
			Assert.AreEqual(1, (int)MediaType.Application);
			Assert.AreEqual(2, (int)MediaType.Audio);
			Assert.AreEqual(4, (int)MediaType.Image);
			Assert.AreEqual(8, (int)MediaType.Text);
			Assert.AreEqual(9, (int)MediaType.Video);
		}

		[Test]
		public void ApplicationTypeTests()
		{
			var formats = new[] { "js", "json", "swf", "xap", "zip" };

			formats.Each(format => Assert.AreEqual(MediaType.Application, Mime.FromFormat(format).Type));
		}

		[Test]
		public void TextTypeTests()
		{
			// Text
			var formats = new[] { "css", "csv", "txt", "xml" };

			formats.Each(format => Assert.AreEqual(MediaType.Text, Mime.FromFormat(format).Type));
		}

		[Test]
		public void AudioTypeTests()
		{
			var formats = new[] { "aac", "mp3", "ra", "wav", "wma" };

			formats.Each(format => Assert.AreEqual(MediaType.Audio, Mime.FromFormat(format).Type));
		}

		[Test]
		public void ImageTypeTests()
		{
			var formats = new[] { "bmp", "gif", "ico", "jpg", "jpeg", "jxr", "png", "tif", "tiff" };

			formats.Each(format => Assert.AreEqual(MediaType.Image, Mime.FromFormat(format).Type));
		}

		[Test]
		public void VideoTypeTests()
		{
			var formats = new[] { "avi", "f4v", "flv", "m4v", "mp4", "mpg", "mpeg", "qt", "webm", "wmv" };

			formats.Each(format => Assert.AreEqual(MediaType.Video, Mime.FromFormat(format).Type));
		}
	}
}