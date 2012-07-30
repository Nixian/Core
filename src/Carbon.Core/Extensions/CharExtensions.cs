namespace Carbon.Helpers
{
	using System;

	public static class CharExtensions
	{
		public static string HexEscape(this char c)
		{
			// String.Format("{0:X2}", (int)symbol)

			return Uri.HexEscape(c);
		}

		public static bool IsLetter(this char c)
		{
			return Char.IsLetter(c);
		}

		public static bool IsNumber(this char c)
		{
			return Char.IsNumber(c);
		}

		public static bool IsDigit(this char c)
		{
			return Char.IsDigit(c);
		}

		public static bool IsWhiteSpace(this char c)
		{
			return Char.IsWhiteSpace(c);
		}

		public static bool IsVowel(this char c)
		{
			switch (c) {
				case 'a':
				case 'e':
				case 'i':
				case 'o':
				case 'u': return true;

				default: return false;
			}
		}
	}
}