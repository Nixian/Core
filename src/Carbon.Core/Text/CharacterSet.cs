namespace Carbon.Helpers
{
	using System;
	using System.Collections;
	using System.Collections.ObjectModel;
	using System.Collections.Generic;

	public class CharacterSet : IList<char>
	{
		private readonly char[] items;

		public CharacterSet(char[] items)
		{
			this.items = items;
		}

		public bool Contains(char item)
		{
			return Array.BinarySearch(items, item) > -1;
		}

		public int Count
		{
			get { return items.Length; }
		}

		// UnreservedUrlCharacters
		// unreserved  = ALPHA / DIGIT / "-" / "." / "_" / "~"
		// public const string UrlSafeString = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-_.~";

		public static readonly char[] UrlSafeCharacters = { 
			/* 45 - 46 */	'-','.',
			/* 48 - 57 */	'0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 
			/* 64 - 90  */	'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z', 
			/* 95 */		'_',
			/* 97 - 122 */	'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z',
			/* 126 */		'~' };


		// lower and upper case alphanumeric characters 
		// expect 0, O, o, 1, I, i, and l 
		private static readonly char[] UnambigiousCharacters = { 
			'2', '3', '4', '5', '6', '7', '8', '9',
			'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'J', 'K', 'L', 'M', 'N', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z', 
			'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'm', 'n', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };

		public static readonly CharacterSet UrlSafe = new CharacterSet(UrlSafeCharacters);

		/// <summary>
		/// Visually unambigious characters
		/// Excludes ( 0, O, o, 1, I, i, and l)
		/// </summary>
		public static readonly CharacterSet Unambigious = new CharacterSet(UrlSafeCharacters);

		#region IList

		int IList<char>.IndexOf(char item)
		{
			return Array.BinarySearch(items, item);
		}

		void IList<char>.Insert(int index, char item)
		{
			throw new NotImplementedException();
		}

		void IList<char>.RemoveAt(int index)
		{
			throw new NotImplementedException();
		}

		public char this[int index]
		{
			get { return items[index]; }
			set
			{
				throw new NotImplementedException();
			}
		}

		void ICollection<char>.Add(char item)
		{
			throw new NotImplementedException();
		}

		void ICollection<char>.Clear()
		{
			throw new NotImplementedException();
		}

		void ICollection<char>.CopyTo(char[] array, int arrayIndex)
		{
			throw new NotImplementedException();
		}

		bool ICollection<char>.IsReadOnly
		{
			get { return true; }
		}

		bool ICollection<char>.Remove(char item)
		{
			throw new NotImplementedException();
		}

		IEnumerator<char> IEnumerable<char>.GetEnumerator()
		{
			return ((IList<char>)items).GetEnumerator();
		}

		IEnumerator System.Collections.IEnumerable.GetEnumerator()
		{
			return items.GetEnumerator();
		}

		#endregion
	}
}