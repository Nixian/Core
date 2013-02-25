namespace Carbon.Color
{
	using System;

	using Carbon.Helpers;

	public struct WebColor : IColor
	{
		private readonly byte red;
		private readonly byte green;
		private readonly byte blue;
		private readonly byte alpha;

		private static readonly WebColor Red	= new WebColor(255, 0, 0);
		private static readonly WebColor Green	= new WebColor(0, 255, 0);
		private static readonly WebColor Blue	= new WebColor(0, 0, 255);

		public WebColor(byte red, byte green, byte blue, byte alpha = 255)
		{
			this.red = red;
			this.green = green;
			this.blue = blue;
			this.alpha = alpha;
		}

		public string ToHex()
		{
			return ToHex(red) + ToHex(green) + ToHex(blue);
		}

		public string ToHex(byte value)
		{
			return string.Concat("0123456789ABCDEF"[(value - value % 16) / 16], "0123456789ABCDEF"[value % 16]);
		}

		public static WebColor Parse(string hex)
		{
			#region Preconditions

			if (hex == null)		throw new ArgumentNullException("hex");
			// if (hex.Length)	throw new ArgumentException("must be 6", "hex.length");

			#endregion

			// 000000

			hex = hex.TrimStart('#');

			var data = HexString.ToBytes(hex);

			return new WebColor(data[0], data[1], data[2]);
		}

		public override string ToString()
		{
			return '#' + ToHex();
		}
	}
}
