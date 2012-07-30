﻿namespace Carbon.Helpers
{
	using System;
	using System.Text;

	/// <summary>
	/// Hexidecimal string
	/// </summary>
	public static class HexString
	{
		/// <summary>
		/// Converts a byte array to a hexidecimal string
		/// </summary>
		public static string FromBytes(byte[] bytes)
		{
			#region Preconditions

			if (bytes == null)
				throw new ArgumentNullException("bytes");

			#endregion

			var sb = new StringBuilder(bytes.Length * 2);

			foreach (byte b in bytes) {
				sb.Append(b.ToString("x2"));
			}

			return sb.ToString();
		}

		public static byte[] ToBytes(string hexString) 
		{
			#region Preconditions

			if (hexString == null)
				throw new ArgumentNullException("hexString");

			if (hexString.Length % 2 != 0)
				throw new ArgumentException("Must be divisible by 2");

			#endregion

			byte[] bytes = new byte[hexString.Length / 2];

			for (int i = 0; i < hexString.Length; i += 2) {
				bytes[i / 2] = Convert.ToByte(hexString.Substring(i, 2), 16);
			}

			return bytes;
		}
	}
}