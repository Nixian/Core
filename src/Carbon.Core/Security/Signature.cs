namespace Carbon.Security
{
	using System;
	using System.Security.Cryptography;
	using System.Text;

	using Carbon.Helpers;

	public class Signature
	{
		private readonly byte[] data;

		public Signature(byte[] data)
		{
			this.data = data;
		}

		public byte[] Data
		{
			get { return data; }
		}

		public string ToHexString()
		{
			return HexString.FromBytes(data);
		}

		public string ToBase64String()
		{
			return Convert.ToBase64String(data);
		}

		public static Signature ComputeHmacSha1(string key, string data)
		{
			return Compute(SignatureAlgorithm.HMACSHA1, key, data);
		}

		public static Signature ComputeHmacSha256(string key, string data)
		{
			return Compute(SignatureAlgorithm.HMACSHA256, key, data);
		}

		public static Signature Compute(SignatureAlgorithm type, string key, string data)
		{
			return Compute(type, key: Encoding.UTF8.GetBytes(key), data: Encoding.UTF8.GetBytes(data));
		}

		public static Signature Compute(SignatureAlgorithm type, byte[] key, byte[] data)
		{
			#region Preconditions

			if (key == null)
				throw new ArgumentNullException("key");

			if (data == null)
				throw new ArgumentNullException("data");

			#endregion

			using (var algorithm = CreateAlgoritm(type, key))
			{
				byte[] hash = algorithm.ComputeHash(data);

				return new Signature(hash);
			}
		}

		public static KeyedHashAlgorithm CreateAlgoritm(SignatureAlgorithm algorithmType, byte[] key)
		{
			switch (algorithmType)
			{
				case SignatureAlgorithm.HMACSHA1:	return new HMACSHA1(key); 
				case SignatureAlgorithm.HMACSHA256:	return new HMACSHA256(key);

				default: throw new ArgumentException("Unsupported algorithmType");
			}
		}

		public enum SignatureAlgorithm
		{
			HMACSHA1,
			HMACSHA256
		}
	}
}
