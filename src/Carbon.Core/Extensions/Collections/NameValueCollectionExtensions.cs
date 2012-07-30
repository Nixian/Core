namespace Carbon.Helpers
{
	using System;
	using System.Collections.Generic;
	using System.Collections.Specialized;
	using System.Text;

	public static class NameValueCollectionExtensions
	{
		public static NameValueCollection Clone(this NameValueCollection nvc)
		{
			var clonedNvc = new NameValueCollection();

			foreach (string key in nvc.Keys) 
			{
				clonedNvc.Add(key, nvc[key]);
			}

			return clonedNvc;
		}

		public static bool ContainsKey(this NameValueCollection nvc, string keyToFind)
		{
			foreach (string key in nvc.Keys) 
			{
				if (key == keyToFind) return true;
			}

			return false;
		}

		public static Dictionary<string, string> ToDictionary(this NameValueCollection nvc)
		{
			var dictionary = new Dictionary<string, string>();

			foreach (string key in nvc.Keys)
			{
				dictionary.Add(key, nvc[key]);
			}

			return dictionary;
		}

		public static string ToPostData(this NameValueCollection nvc)
		{
			#region Preconditions

			if (nvc == null)
				throw new ArgumentNullException("nvc");

			#endregion

			var sb = new StringBuilder();

			foreach (string key in nvc.Keys)
			{
				if (sb.Length > 0)
				{
					sb.Append("&");
				}

				string value = nvc[key].UrlEncode();

				sb.AppendFormat("{0}={1}", key, value);
			}

			return sb.ToString();
		}

		public static string ToQueryString(this NameValueCollection nvc)
		{
			if (nvc.Count == 0) return "";

			return "?" + nvc.ToPostData();
		}
	}
}
