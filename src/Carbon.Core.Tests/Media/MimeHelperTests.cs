namespace Carbon.Helpers.Tests
{
	using NUnit.Framework;

	using Carbon.Media;

	[TestFixture]
	public class MimeHelperTest
	{
		[Test]
		public void GetMimeFromFileFormatTests()
		{
			// Applications
			Assert.AreEqual("application/x-shockwave-flash",	Mime.FromFormat("swf"));
			Assert.AreEqual("application/zip",					Mime.FromFormat("zip"));

			// Audio
			Assert.AreEqual("audio/mpeg",						Mime.FromFormat("mp3"));
			Assert.AreEqual("audio/x-ms-wma",					Mime.FromFormat("wma"));

			// Documents
			Assert.AreEqual("application/pdf",					Mime.FromFormat("pdf"));
			Assert.AreEqual("application/msword",				Mime.FromFormat("doc"));

			// Images
			Assert.AreEqual("image/bmp",	Mime.FromFormat("bmp"));
			Assert.AreEqual("image/x-icon", Mime.FromFormat("ico"));
			Assert.AreEqual("image/jpeg",	Mime.FromFormat("jpg"));
			Assert.AreEqual("image/jpeg",	Mime.FromFormat("jpeg"));
			Assert.AreEqual("image/png",	Mime.FromFormat("png"));
			Assert.AreEqual("image/tiff",	Mime.FromFormat("tif"));
			Assert.AreEqual("image/tiff",	Mime.FromFormat("tiff"));

			// Scripts
			Assert.AreEqual("application/javascript", Mime.FromFormat("js"));

			// Text
			Assert.AreEqual("text/html", Mime.FromFormat("htm"));
			Assert.AreEqual("text/html", Mime.FromFormat("html"));
			Assert.AreEqual("text/plain", Mime.FromFormat("txt"));

			// Videos
			Assert.AreEqual("video/x-msvideo", Mime.FromFormat("avi"));
			Assert.AreEqual("video/mp4", Mime.FromFormat("f4v"));
			Assert.AreEqual("video/mp4", Mime.FromFormat("m4v"));
			Assert.AreEqual("video/quicktime", Mime.FromFormat("mov"));
			Assert.AreEqual("video/mp4", Mime.FromFormat("mp4"));
			Assert.AreEqual("video/mpeg", Mime.FromFormat("mpeg"));
			Assert.AreEqual("video/quicktime", Mime.FromFormat("qt"));
			Assert.AreEqual("video/webm", Mime.FromFormat("webm"));

			// Make sure we don't care about a leading dot or casing
			Assert.AreEqual("image/jpeg", Mime.FromFileExtension(".JpG"));
			Assert.AreEqual("image/png", Mime.FromFileExtension(".pNG"));
			Assert.AreEqual("audio/mpeg", Mime.FromFileExtension(".mP3"));

			// FID
			Assert.AreEqual("application/octet-stream", Mime.FromFormat(".FID"));
		}

		[Test]
		public void StaticMimeMappingTests()
		{
			Assert.AreEqual("application/javascript", Mime.Js);
			Assert.AreEqual("application/x-shockwave-flash", Mime.Swf);
		}

		/*
		[Test]
		public void GetFormatFromMimeTests()
		{
			// Images
			Assert.AreEqual("jpeg",	FileFormat.FromMime("image/jpeg"));
			Assert.AreEqual("png",	FileFormat.FromMime("image/png"));

			// Documents
			Assert.AreEqual("doc",	FileFormat.FromMime("application/msword"));
			Assert.AreEqual("pdf",	FileFormat.FromMime("application/pdf"));

			// Videos
			Assert.AreEqual("mp4",	FileFormat.FromMime("video/mp4"));

			// Misc
			Assert.AreEqual("swf",	FileFormat.FromMime("application/x-shockwave-flash"));
			Assert.AreEqual("zip",	FileFormat.FromMime("application/zip"));
		}
		*/
	}
}