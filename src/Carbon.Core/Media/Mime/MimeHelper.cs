namespace Carbon.Media
{
    using System;
	using System.Collections.Generic;
	using System.Linq;

	using Carbon.Helpers;

	public static class MimeHelper
	{
		public static readonly Dictionary<string, string> FormatToMimeMap = new Dictionary<string,string>(StringComparer.OrdinalIgnoreCase) {
			// Applications: Documents
			{ "doc",	Mime.Doc },
			{ "pdf",	Mime.Pdf },

			// Applications: Packages
			{ "zip",	Mime.Zip },

			// Applications: Scripts
			{ "js",		Mime.Js },		// JavaScript
            { "py",		Mime.Py },		// Python

			// Applications: Plugins
			{ "swf",	Mime.Swf },
			{ "xap",	Mime.Xap },

			// Applications: Fonts
			{ "eot",	Mime.Eot },
			{ "ttf",	Mime.Ttf },
			{ "woff",	Mime.Woff },
			

			// Audio
			{ "aac",	Mime.Aac },
			{ "mp3",	Mime.Mp3 },
			{ "ra",		Mime.Ra },
			{ "wav",	Mime.Wav },
			{ "wma",	Mime.Wma },

			// Images 
			{ "bmp",	Mime.Bmp },
			{ "gif",	Mime.Gif },
			{ "hdp",	Mime.Jxr },
			{ "ico",	Mime.Ico },
			{ "jpg",	Mime.Jpeg },
			{ "jpeg",	Mime.Jpeg },
			{ "jxr",	Mime.Jxr },		// Jpeg XR
			{ "png",	Mime.Png },
			{ "svg",	Mime.Svg },
			{ "tif",	Mime.Tiff },
			{ "tiff",	Mime.Tiff },
			{ "wdp",	Mime.Jxr },

			// Text
			{ "css",	Mime.Css },
			{ "htm",	Mime.Html },
			{ "html",	Mime.Html },
			{ "txt",	Mime.Txt },
			{ "xml",	Mime.Xml },

			// Videos
			{ "avi",	Mime.Avi },
			{ "f4v",	Mime.F4v },
			{ "flv",	Mime.Flv },
			{ "m4v",	Mime.Mp4 },
			{ "mpg",	Mime.Mpeg },
			{ "mpeg",	Mime.Mpeg },
			{ "mov",	Mime.Mov },
			{ "mp4",	Mime.Mp4 },
			{ "ts",		Mime.Ts },
			{ "qt",		Mime.Mov },
			{ "webm",	Mime.WebM },
			{ "wmv",	Mime.Wmv }
		};

		public static MediaType GetMediaTypeFromFileExtension(string fileExtension)
		{
			#region Preconditions

			if (fileExtension == null)
				throw new ArgumentNullException("fileExtension");

			#endregion

			var format = fileExtension.TrimStart('.');

			return GetMediaTypeFromFormat(format);
		}

		public static MediaType GetMediaTypeFromFormat(string format)
		{
			#region Preconditions

			if (format == null)
				throw new ArgumentNullException("format");

			#endregion

			string mime;
			
			if(FormatToMimeMap.TryGetValue(format, out mime)) {
				return mime.Split('/')[0].ToEnum<MediaType>(ignoreCase: true);
			}

			return MediaType.Unknown;
		}
	}
}
