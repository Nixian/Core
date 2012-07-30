namespace Carbon.Validation
{
	using System;

	[AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
	public class StringLengthAttribute : System.ComponentModel.DataAnnotations.StringLengthAttribute 
	{
		public StringLengthAttribute(int maximumLength)
			: base(maximumLength) { }

		public StringLengthAttribute(int minimumLength, int maximumLength)
			: base(maximumLength)
		{
			this.MinimumLength = minimumLength;
		}
	}
}