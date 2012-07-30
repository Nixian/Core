namespace Carbon.Media
{
	using System;
	using System.IO;

	public static class FileFormat
	{
		/*
		public static string FromMime(string mime)
		{
			string format;

			if (!MimeHelper.MimeToFormatMap.TryGetValue(mime, out format)) {
				throw new ArgumentException("Mime named '{0}' not found".FormatWith(mime));
			}

			return format;
		}
		*/

		public static string Normalize(string format)
		{
			#region Preconditions

			if (format == null)
				throw new ArgumentNullException("format");

			#endregion

			// Strip any leading periods and convert to lowercase
			format = format.TrimStart('.').ToLower();

			switch (format)
			{
				case "jpg": return "jpeg";
				case "tif": return "tiff";
				case "mpg": return "mpeg";

				default:	return format;
			}
		}

		public static string FromPath(string path)
		{
			var extension = Path.GetExtension(path);

			return Normalize(extension);
		}
	}
}