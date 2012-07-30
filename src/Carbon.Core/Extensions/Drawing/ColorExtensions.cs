namespace Carbon.Helpers
{
	using System.Drawing;

	public static class ColorExtensions
	{
		public static string ToHex(this Color color) {
			return "{0:X2}{1:X2}{2:X2}".FormatWith(color.R, color.G, color.B);
		}
	}
}