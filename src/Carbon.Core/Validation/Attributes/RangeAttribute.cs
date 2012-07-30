namespace Carbon.Validation
{
	using System;

	[AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
	public class RangeAttribute : System.ComponentModel.DataAnnotations.RangeAttribute 
	{
		public RangeAttribute(int minimum, int maximum)
			: base(minimum, maximum) { }
	}
}