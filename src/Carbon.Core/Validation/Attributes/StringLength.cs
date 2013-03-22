namespace Carbon.Validation
{
	using System;

	using Carbon.Helpers;

	[AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
	public class StringLengthAttribute : System.ComponentModel.DataAnnotations.StringLengthAttribute 
	{
		public StringLengthAttribute(int maximumLength)
			: base(maximumLength) 
		{
				this.ErrorMessage = "Must be {0} characters or fewer.".FormatWith(maximumLength);
		}

		public StringLengthAttribute(int minimumLength, int maximumLength)
			: base(maximumLength)
		{
			this.MinimumLength = minimumLength;
		}
	}
}