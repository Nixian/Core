namespace Carbon.Validation
{
	using System;
	using System.ComponentModel.DataAnnotations;

	[AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
	public class DivisibleByAttribute : ValidationAttribute 
	{
		private readonly int divisibleBy;

		public DivisibleByAttribute(int divisibleBy)
		{
			this.divisibleBy = divisibleBy;
		}

		public override bool IsValid(object value)
		{
			var number = (int)value;

			return number % divisibleBy == 0;
		}
	}
}