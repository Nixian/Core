namespace Carbon.Helpers
{
	using System;

	public class CharacterSet
	{
		private readonly char[] items;

		public CharacterSet(char[] items)
		{
			this.items = items;
		}

		public bool Contains(char c)
		{
			return Array.BinarySearch(items, c) > -1;
		}

		// UnreservedUrlCharacters
		// unreserved  = ALPHA / DIGIT / "-" / "." / "_" / "~"
		// public const string UrlSafeString = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-_.~";

		public static readonly char[] UrlSafeArray = new[] { 
			/* 45 - 46 */	'-','.',
			/* 48 - 57 */	'0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 
			/* 64 - 90  */	'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z', 
			/* 95 */		'_',
			/* 97 - 122 */	'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z',
			/* 126 */		'~' };
		
		public static readonly CharacterSet UrlSafe = new CharacterSet(UrlSafeArray);
	}
}