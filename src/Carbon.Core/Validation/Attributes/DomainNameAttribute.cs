namespace Carbon.Validation
{
	using System;
	using System.ComponentModel.DataAnnotations;

	[AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
	public class DomainNameAttribute : ValidationAttribute
	{
		public override bool IsValid(object value)
		{
			var text = value as string;

			if (value == null) return true;

			if (!text.Contains(".")) return false;

			Uri uri;

			return Uri.TryCreate("http://" + value, UriKind.Absolute, out uri);
		}
	}
}