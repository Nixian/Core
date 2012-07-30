namespace Carbon.Validation
{
	using System;
	using System.ComponentModel.DataAnnotations;

	[AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
	public class MustEqualAttribute : ValidationAttribute
	{
		private readonly object equalToValue;

		public MustEqualAttribute(object equalToValue)
		{
			this.equalToValue = equalToValue;
		}

		public override bool IsValid(object value)
		{
			if (value == null) {
				return true;
			}

			return value.Equals(equalToValue);
		}
	}
}