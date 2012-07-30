namespace Carbon.Validation
{
	using System;
	using System.ComponentModel.DataAnnotations;

	using Carbon.Helpers;

	[AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
	public class TimeZoneAttribute : ValidationAttribute
	{
		public TimeZoneAttribute() { }

		public override bool IsValid(object value)
		{
			string text = value as string;

			if (text.IsNullOrEmpty())
				return true;

			return TZMap.Items.ContainsKey(text);
		}
	}
}