namespace Carbon.Security
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Reflection;
	using System.Text.RegularExpressions;

	using Carbon.Helpers;
	using Carbon.Reflection;

	public class Sanitizer
	{
		public static void Sanitize(object entity)
		{
			if (entity == null)
				return;

			// Get the properties that need to be santized
			var propertiesNeedingSantation = GetPropertiesNeedingSanitation(entity.GetType());

			foreach (var property in propertiesNeedingSantation)
			{
				// Get the current property value
				string value = entity.GetPropertyValue<string>(property);

				if (value.IsNullOrEmpty()) {
					continue;
				}

				var sanitizeAttribute = property.GetFirstCustomAttribute<SanitizeAttribute>();

				// Strip script and html tags if HTML is not allowed - otherwise, just strip out the script tags
				value = (sanitizeAttribute.AllowHtml) ? value.StripJavaScript() : value.StripJavaScript().StripTags();

				if (sanitizeAttribute.Trim) {
					value = value.Trim();
				}

				// Add nofollow refs rel="nofollow"

				if (sanitizeAttribute.AddNoFollowsToLinks) {
					value = AddNoFollows(value);
				}

				// Set the property value to the new santized value
				property.SetValue(entity, value);
			}
		}

		public static IEnumerable<PropertyInfo> GetPropertiesNeedingSanitation(Type type)
		{
			#region Preconditions

			if (type == null)
				throw new ArgumentNullException("type");

			#endregion

			return type.GetProperties().Where(property => property.HasCustomAttribute<SanitizeAttribute>());
		}

		public static string AddNoFollows(string text)
		{
			return Regex.Replace(text, @"(<a\s*(?!.*\brel=)[^>]*)(href=""https?://)(([^""])+)", "$1$2$3\" rel=\"nofollow", RegexOptions.Multiline);
		}
	}
}