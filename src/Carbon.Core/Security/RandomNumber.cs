namespace Carbon.Security
{
	using System;
	using System.Security.Cryptography;

	public static class RandomNumber
	{
		private static RandomNumberGenerator rng = new RNGCryptoServiceProvider();

		public static int Generate(int min, int max)
		{
			var randomData = new byte[4];

			rng.GetBytes(randomData);

			var seed = BitConverter.ToInt32(randomData, 0);

			var random = new Random(seed);

			return random.Next(min, max + 1);
		}
	}
}