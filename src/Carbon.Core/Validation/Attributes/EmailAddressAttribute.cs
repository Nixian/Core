namespace Carbon.Validation
{
	using System;
	using System.ComponentModel.DataAnnotations;

	[AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
	public class EmailAddressAttribute : DataTypeAttribute
	{
		public EmailAddressAttribute()
			: base(DataType.EmailAddress) { }

		public override bool IsValid(object value)
		{
			string text = value as string;

			if (string.IsNullOrEmpty(text)) 
				return true;

			// http://stackoverflow.com/questions/386294/maximum-length-of-a-valid-email-id
			if (text.Length > 254)
				return false;

			return ValidationHelper.IsValidEmailAddress(text);
		}
	}
}