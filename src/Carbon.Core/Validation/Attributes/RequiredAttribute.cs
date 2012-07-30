namespace Carbon.Validation
{
	using System;

	[AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
	public class RequiredAttribute : System.ComponentModel.DataAnnotations.RequiredAttribute { }
}