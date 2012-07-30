namespace Carbon.Helpers
{
	using System;
	using System.Collections.Generic;
	using System.IO;
	using System.Text;
	using System.Web;

	public static class StringExtensions
	{
		public static bool IsAnsi(this string text)
		{
			if (text.IsNullOrEmpty())
				return true;

			foreach (char c in text)
			{
				if (c > '\x00ff') {
					return false;
				}
			}

			return true;
		}

		public static string HtmlEncode(this string text)
		{
			if (text.IsNullOrEmpty()) return text;

			return HttpUtility.HtmlEncode(text);
		}

		public static string UrlDecode(this string text)
		{
			if (text.IsNullOrEmpty()) return text;

			return HttpUtility.UrlDecode(text);
		}

		public static string UrlEncode(this string text)
		{
			if (text.IsNullOrEmpty()) return text;

			return HttpUtility.UrlEncode(text);
		}

		public static bool IsNullOrEmpty(this string text) {
			return String.IsNullOrEmpty(text);
		}

		public static IEnumerable<string> SplitLines(this string text)
		{
			#region Preconditions

			if (text == null)
				throw new ArgumentNullException("text");

			#endregion

			using (var reader = new StringReader(text))
			{
				string line;

				while ((line = reader.ReadLine()) != null) 
				{
					yield return line;
				}
			}
		}

		public static string[] SplitIntoSegments(this string text, int segementLength)
		{
			int totalSegements = (int)Math.Ceiling((double)text.Length / (double)segementLength);
			string[] segments = new string[totalSegements];

			for (int i = 0; i < totalSegements; i++)
			{
				int start = i * segementLength;
				int end = start + segementLength;

				if (end >= text.Length) {
					end = text.Length;
				}

				segments[i] = text.Substring(start, end - start);
			}

			return segments;
		}

		public static string FormatWith(this string format, params object[] args)
		{
			#region Preconditions

			if (format == null)
				throw new ArgumentNullException("format");

			#endregion

			return string.Format(format, args);
		}

		public static TEnum ToEnum<TEnum>(this string self)
		{
			#region Preconditions

			if (self == null) 
				throw new ArgumentNullException("self");

			#endregion

			return (TEnum)Enum.Parse(typeof(TEnum), self);
		}

		public static TEnum ToEnum<TEnum>(this string self, bool ignoreCase)
			where TEnum : struct
		{
			#region Preconditions

			if (self == null)
				throw new ArgumentNullException("self");

			#endregion

			TEnum result;

			Enum.TryParse(self, ignoreCase, out result);

			return result;
		}

		public static int ToInt(this string number)
		{
			if (String.IsNullOrEmpty(number))
				return 0;

			int result;

			Int32.TryParse(number, out result);

			return result;
		}

		public static short ToShort(this string number)
		{
			short shortValue;

			Int16.TryParse(number, out shortValue);

			return shortValue;
		}

		public static int? ToNullableInt(this string number)
		{
			int intValue;

			if(Int32.TryParse(number, out intValue)) {
				return intValue;
			}

			return null;
		}

		public static float ToFloat(this string number)
		{
			float floatValue;

			float.TryParse(number, out floatValue);

			return floatValue;
		}

		public static decimal ToDecimal(this string number)
		{
			decimal decimalValue;

			Decimal.TryParse(number, out decimalValue);

			return decimalValue;
		}

		public static long ToLong(this string number)
		{
			long longValue;

			Int64.TryParse(number, out longValue);

			return longValue;
		}

		public static double ToDouble(this string number)
		{
			double doubleValue;

			Double.TryParse(number, out doubleValue);

			return doubleValue;
		}

		public static bool IsValidUri(this string text)
		{
			if (text.IsNullOrEmpty()) {
				return false;
			}

			Uri uri;

			return Uri.TryCreate(text, UriKind.Absolute, out uri);
		}

		public static Uri ToUri(this string text)
		{
			if (text.IsNullOrEmpty()) {
				return null;
			}

			text = text.Trim();

			// Check if it begins with http
			if (!(text.StartsWith("http://") || text.StartsWith("https://"))) {
				text = "http://" + text;
			}

			Uri uri;

			Uri.TryCreate(text, UriKind.Absolute, out uri);

			return uri;
		}
	}
}