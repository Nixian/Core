namespace Carbon.Reflection
{
	using System;
	using System.Reflection;

	public static class PropertyInfoExtensions
	{
		/// <summary>
		/// Sets the property value of the object. Returns whether the binding was succesful
		/// </summary>
		public static bool SetValue(this PropertyInfo propertyInfo, object instance, object value)
		{
			if (!propertyInfo.CanWrite) return false;

			propertyInfo.SetValue(instance, value, null);

			return true;
		}
	}
}
