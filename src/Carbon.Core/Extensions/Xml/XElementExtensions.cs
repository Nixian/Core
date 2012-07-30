namespace Carbon.Helpers
{
	using System.Xml.Linq;

	public static class XElementExtensions
	{
		public static bool HasValue(this XElement instance) {
			return (instance != null && instance.Value.IsNullOrEmpty());
		}
	}
}