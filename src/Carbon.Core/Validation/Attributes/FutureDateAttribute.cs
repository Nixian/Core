namespace Carbon.Validation
{
	using System;
	using System.ComponentModel.DataAnnotations;

	[AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
	public class FutureDateAttribute : ValidationAttribute
	{
		public override bool IsValid(object value)
		{
			if (value == null) return true;

			if (value is DateTime?)
			{
				return ((DateTime?)value).Value >= DateTime.UtcNow;
			}
			else if (value is DateTime)
			{
				return (DateTime)value >= DateTime.UtcNow;
			}

			return false;
		}
	}
}