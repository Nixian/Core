namespace Carbon.Helpers
{
	using System;
	using System.IO;

	public static class IOHelper
	{
		private static readonly string[] ByteMultiples = { "B", "KB", "MB", "GB", "TB", "PB", "EB" };

		public const long BytesInKilobyte = 1024;						// 1,024
		public const long BytesInMegabyte = BytesInKilobyte * 1024;		// 1,048,576
		public const long BytesInGigabyte = BytesInMegabyte * 1024;		// 1,073,741,824
		public const long BytesInTerabyte = BytesInGigabyte * 1024;		// 1,099,511,627,776
		public const long BytesInPetabyte = BytesInTerabyte * 1024;		// 1,125,899,906,842,620
		public const long BytesInExabyte  = BytesInPetabyte * 1024;		// 1,152,921,504,606,850,000

		public static bool TryCreateDirectory(string path)
		{
			#region Preconditions

			if (path == null)
				throw new ArgumentNullException("path");

			#endregion

			var di = new DirectoryInfo(Path.GetDirectoryName(path));

			if (di.Exists) return false;

			di.Create();

			return true;
		}

        public static string FormatBytes(long byteCount) 
		{
			int i = 0;

			double value = byteCount;

			while (1023 < value) 
			{
				value /= 1024;

				i++;
			}

			return String.Concat(ThreeNonZeroDigits(value), " ", ByteMultiples[i]);
        }

		// TODO: i > 6

        private static string ThreeNonZeroDigits(double value)
        {
			if (value >= 100) 
			{
				return ((int)value).ToString();
			}

			if (value >= 10)
			{
				return value.ToString("0.0");
			}

			return value.ToString("0.00");
        }
	}
}

