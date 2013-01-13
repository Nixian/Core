namespace Carbon.Reflection
{
	using System;
	using System.Reflection;

	public static class PropertyInfoExtensions
	{
		public static void SetValue(this PropertyInfo propertyInfo, object instance, object value)
		{
			#region Preconditions

			if (!propertyInfo.CanWrite) throw new Exception("Property is not writable.");

			#endregion

			propertyInfo.SetValue(instance, value, null);
		}
	}
}