namespace Carbon.Models
{
	using System;
	using System.Collections.Generic;
	using System.Text;

	public static class AddressExtensions
	{
		public static IEnumerable<string> ToLines(this IAddress address)
		{
			#region Preconditions

			if (address == null)
				throw new ArgumentNullException("address");

			#endregion

			// Line 1
			if (!String.IsNullOrWhiteSpace(address.Line1))
				yield return address.Line1;

			// Line 2
			if (!String.IsNullOrWhiteSpace(address.Line2))
				yield return address.Line2;

			#region Line 3

			var line3Sb = new StringBuilder();

			// City
			if (!String.IsNullOrWhiteSpace(address.City))
				line3Sb.Append(address.City);

			// ,
			if (!String.IsNullOrWhiteSpace(address.City) && !String.IsNullOrWhiteSpace(address.Region))
				line3Sb.Append(", ");

			// Region
			if (!String.IsNullOrWhiteSpace(address.Region))
				line3Sb.Append(address.Region);

			// Postal Code
			if (!String.IsNullOrWhiteSpace(address.PostalCode))
				line3Sb.Append(" " + address.PostalCode);

			var line3Text = line3Sb.ToString().Trim();

			if (line3Text.Length > 0)
				yield return line3Text;

			#endregion

			// Country
			if (!String.IsNullOrWhiteSpace(address.Country))
				yield return address.Country;
		}

		public static string ToHtml(this IAddress address)
		{
			#region Preconditions

			if (address == null)
				throw new ArgumentNullException("address");

			#endregion

			return string.Join("<br />\r\n", address.ToLines());
		}
	}
}
