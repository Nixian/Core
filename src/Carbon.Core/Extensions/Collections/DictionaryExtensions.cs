namespace Carbon.Helpers
{
	using System.Collections.Generic;
	using System.Collections.Specialized;

	public static class DictionaryExtensions
	{
		public static NameValueCollection ToNameValueCollection(this Dictionary<string, string> dictionary)
		{
			var nvc = new NameValueCollection();

			foreach (var pair in dictionary)
			{
				nvc.Add(pair.Key, pair.Value);
			}

			return nvc;
		}
	}
}
