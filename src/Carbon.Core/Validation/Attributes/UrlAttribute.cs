namespace Carbon.Validation
{
	using System;
	using System.ComponentModel.DataAnnotations;

	using Carbon.Helpers;

	[AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
	public class UrlAttribute : DataTypeAttribute
	{
		public UrlAttribute()
			: base(DataType.Url) { }

		public override bool IsValid(object value)
		{
			var text = value as string;

			if (value == null) return true;

			var url = text.ToUri();

			return url != null;
		}
	}
}