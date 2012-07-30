﻿namespace Carbon.Validation
{
	using System;
	using System.ComponentModel.DataAnnotations;

	[AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
	public class NoNumbersAttribute : ValidationAttribute 
	{
		public override bool IsValid(object value)
		{
			var text = value as string;

			if (string.IsNullOrEmpty(text)) return true;

			return !ValidationHelper.ContainsNumbers(text);
		}
	}
}