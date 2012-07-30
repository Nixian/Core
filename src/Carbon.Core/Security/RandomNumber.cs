namespace Carbon.Security
{
	using System;
	using System.Security.Cryptography;

	public static class RandomNumber
	{
		public static int Generate(int min, int max)
		{
			var rng = new RNGCryptoServiceProvider();

			byte[] randomData = new byte[4];

			rng.GetBytes(randomData);

			var seed = BitConverter.ToInt32(randomData, 0);

			var random = new Random(seed);

			return random.Next(min, max + 1);
		}
	}
}