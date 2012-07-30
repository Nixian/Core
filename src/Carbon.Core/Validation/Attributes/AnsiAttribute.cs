namespace Carbon.Validation
{
	using System;
	using System.ComponentModel.DataAnnotations;

	using Carbon.Helpers;

	[AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
	public class AnsiAttribute : ValidationAttribute
	{
		public override bool IsValid(object value)
		{
			string text = value as string;

			return text.IsAnsi();
		}
	}
}