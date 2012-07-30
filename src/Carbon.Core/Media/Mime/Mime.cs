namespace Carbon.Media
{
	using System;

	using Carbon.Helpers;

	public static class Mime
	{
		// Applications
		public const string Doc =	"application/msword";
		public const string Js =	"application/javascript";
		public const string Json =	"application/json";
		public const string M3u8 =	"application/x-mpegURL";
		public const string Pdf =	"application/pdf";
		public const string Py =	"application/x-python";
		public const string Swf =	"application/x-shockwave-flash";
		public const string Xap =	"application/x-silverlight-app";
		public const string Zip =	"application/zip";

		// Applications - Fonts
		public const string Eot =	"application/vnd.ms-fontobject";
		public const string Ttf =	"application/x-font-ttf";
		public const string Woff =	"application/x-font-woff";

		// Audio
		public const string Aac =	"audio/mp4";
		public const string Mp3 =	"audio/mpeg";
		public const string Ra =	"audio/x-realaudio";
		public const string Wav =	"audio/wav";
		public const string Wma =	"audio/x-ms-wma";

		// Image
		public const string Bmp =	"image/bmp";
		public const string Gif =	"image/gif";
		public const string Ico =	"image/x-icon";	// See [0]
		public const string Jpeg =	"image/jpeg";
		public const string Jxr =	"image/vnd.ms-photo";
		public const string Png =	"image/png";
		public const string Svg =	"image/svg+xml";
		public const string Tiff =	"image/tiff";

		// Video
		public const string Avi =	"video/x-msvideo";
		public const string F4v =	"video/mp4";
		public const string Flv =	"video/x-flv";
		public const string Mov =	"video/quicktime";
		public const string Mp4 =	"video/mp4";
		public const string Mpeg =	"video/mpeg";
		public const string Ts =	"video/MP2T";
		public const string WebM =	"video/webm";
		public const string Wmv =	"video/x-ms-wmv";

		// Text
		public const string Css =	"text/css";
		public const string Html =	"text/html";
		public const string Txt =	"text/plain";
		public const string Xml =	"text/xml";

		public static string FromFileExtension(string fileExtension)
		{
			#region Preconditions

			if (fileExtension == null)
				throw new ArgumentNullException("fileExtension");

			#endregion

			string format = fileExtension.TrimStart('.');

			return FromFormat(format);
		}

		public static string FromFormat(string format)
		{
			#region Preconditions

			if (format == null)
				throw new ArgumentNullException("format");

			#endregion

			string mime;

			if (MimeHelper.FormatToMimeMap.TryGetValue(format, out mime)) {
				return mime;
			}

			return "application/octet-stream";
		}
	}
}

// NOTES -----------------------------------------------------------------------------------------------------------------------
// [0]:	Internet Explorer 8 does not accept the official mime type "image/vnd.microsoft.icon". Must be "Content-Type: image/x-icon".