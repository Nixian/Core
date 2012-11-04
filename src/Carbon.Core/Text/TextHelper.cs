namespace Carbon.Helpers
{
	using System;
	using System.IO;
	using System.Linq;
	using System.Text;
	using System.Text.RegularExpressions;
	using System.Threading;

	public static class TextHelper
	{
		public static string ToCamelCase(this string pascalCase)
		{
			if (pascalCase.IsNullOrEmpty()) return pascalCase;

			return pascalCase.Substring(0, 1).ToLower() + pascalCase.Substring(1, pascalCase.Length - 1);
		}

		public static string PascalCaseToUnderscore(string pascalText) 
		{
			return SplitPascalCasedTextAndJoinWithChar(pascalText, '_');
		}

		/// <summary>
		/// Converts camelized text to words. For instance:
		/// <c>OrangeMoon</c> is converted to <c>Orange Moon</c>
		/// </summary>
		/// <param name="pascalText">Content in pascal case</param>
		public static string PascalCaseToWord(string pascalText) 
		{
			return SplitPascalCasedTextAndJoinWithChar(pascalText, ' ');
		}

		private static string SplitPascalCasedTextAndJoinWithChar(string pascalText, char joinChar)
		{
			if (pascalText.IsNullOrEmpty()) return pascalText;

			var sb = new StringBuilder(pascalText.Length + 4);

			char[] chars = pascalText.ToCharArray();

			sb.Append(chars[0]);

			for (int i = 1; i < chars.Length; i++)
			{
				char c = chars[i];

				if (Char.IsUpper(c)) {
					sb.Append(joinChar);
				}

				sb.Append(c);
			}

			return sb.ToString();
		}

		public static string Truncate(this string text, int maximumLength, string suffix = "Е")
		{
			#region Preconditions

			if (suffix == null)
				throw new ArgumentNullException("suffix");

			if (maximumLength <= 0)
			{
				throw new ArgumentException(
					/*message*/ "Must be greater than 0. Was {0}.".FormatWith(maximumLength),
					/*paramName*/ "maximumLength"
				);
			}

			#endregion

			if (text.IsNullOrEmpty() || text.Length <= maximumLength) {
				return text;
			}

			return text.Substring(0, maximumLength) + suffix;
		}

		public static string ToTitleCase(this string text)
		{
			if (text.IsNullOrEmpty()) 
				return text;

			var textInfo = Thread.CurrentThread.CurrentCulture.TextInfo;

			return textInfo.ToTitleCase(text);
		}

		/// <summary>
		/// SLUG: A slug is a few words that describe a post or a page. 
		/// Slugs are usually a URL friendly version of the
		/// post title, but a slug can be anything you like. 
		/// Slugs are meant to be used with permalinks as they help 
		/// describe what the content at the URL is. 
		/// </summary>
		public static string ToSlug(this string text)
		{
			if (text.IsNullOrEmpty()) return text;

			// Trim off leading and trailing spaces
			text = text.Trim();

			// Convert the name to lowercase
			text = text.ToLower();

			// Replace spaces with dashes
			text = text.Replace(" ", "-");

			// Replace "&" with and
			text = text.Replace("&", "and");

			// Fix names like "Joes Bar - Eatery"... remove triple ---
			text = text.Replace("---", "-");

			// Ok Unicode Chars: счу

			// Remove all misc chars
			text = Regex.Replace(text, @"[^a-z0-9счу\-]", "");

			return text;
		}

		public static readonly Regex StripTagsRegex = new Regex(
			pattern: "<[^>]+>",
			options: RegexOptions.IgnoreCase | RegexOptions.Compiled
		);

		public static readonly Regex StripScriptTagsRegex = new Regex(
			pattern: "<script((.|\n)*?)</script>",
			options: RegexOptions.IgnoreCase | RegexOptions.Multiline | RegexOptions.Compiled
		);

		public static readonly Regex StripNonAlphaCharsRegex = new Regex(
			pattern: "[^a-z]",
			options: RegexOptions.IgnoreCase | RegexOptions.Compiled
		);

		public static readonly Regex StripNonAlphaNumericCharsRegex = new Regex(
			pattern: "[^a-z0-9]",
			options: RegexOptions.IgnoreCase | RegexOptions.Compiled
		);

		public static string StripNonAlphaChars(this string text)
		{
			if (text.IsNullOrEmpty()) return text;

			return StripNonAlphaCharsRegex.Replace(text, "");
		}

		public static string StripNonAlphaNumericChars(this string text)
		{
			if (text.IsNullOrEmpty()) return text;

			return StripNonAlphaNumericCharsRegex.Replace(text, "");
		}

		public static string StripNonNumericChars(this string text)
		{
			if (text.IsNullOrEmpty()) return text;

			return string.Concat(text.Where(c => Char.IsDigit(c)));
		}

		public static string StripJavaScript(this string text)
		{
			if (text.IsNullOrEmpty()) return text;

			text = StripScriptTagsRegex.Replace(text, "");

			return Regex.Replace(text, "\"javascript:", "", RegexOptions.IgnoreCase | RegexOptions.Multiline);
		}

		public static string StripTags(this string text)
		{
			if (text.IsNullOrEmpty()) return text;

			return StripTagsRegex.Replace(text, "");

			/*
			var sb = new StringBuilder();

			var readingTag = false;

			int i = 0;

			foreach (var c in text)
			{
				switch (c)
				{
					case '<':	readingTag = true;				break;
					case '>':	readingTag = false;				break;
					default:	if (!readingTag) sb.Append(c);	break;			
				}

				i++;
			}

			return sb.ToString();
			*/
		}

		public static string UrlEncodeX2(this string text)
		{
			if (string.IsNullOrEmpty(text)) return text;

			// Percent encode all unreserved characters
			// The standard HttpUtility.UrlEncode uses x2 (lowercase)

			var urlSafeChars = CharacterSet.UrlSafe;

			var sb = new StringBuilder();

			foreach (char symbol in Encoding.UTF8.GetBytes(text))
			{
				if (urlSafeChars.Contains(symbol))
				{
					sb.Append(symbol);
				}
				else
				{
					sb.Append(symbol.HexEscape());
				}
			}

			return sb.ToString();
		}
	}
}