namespace Carbon.Validation
{
	using System;
	using System.ComponentModel.DataAnnotations;

	[AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
	public class MustNotEqualAttribute : ValidationAttribute
	{
		private readonly object notEqualToValue;

		public MustNotEqualAttribute(object notEqualToValue)
		{
			this.notEqualToValue = notEqualToValue;
		}

		public override bool IsValid(object value)
		{
			if (value == null) {
				return true;
			}

			return !value.Equals(notEqualToValue);
		}
	}
}