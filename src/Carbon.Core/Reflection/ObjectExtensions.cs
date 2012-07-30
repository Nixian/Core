namespace Carbon.Reflection
{
	using System;
	using System.Reflection;

	using Carbon.Helpers;

	public static class ObjectExtensions
	{
		public static T GetPropertyValue<T>(this object instance, string propertyName)
		{
			return (T)instance.GetPropertyValue(propertyName);
		}

		public static object GetPropertyValue(this object instance, string propertyName)
		{
			#region Preconditions

			if (instance == null)
				throw new ArgumentNullException("instance");

			if (propertyName == null)
				throw new ArgumentNullException("propertyName");

			#endregion

			Type type = instance.GetType();

			var propertyInfo = type.GetProperty(
				propertyName,
				BindingFlags.Instance | BindingFlags.Public | BindingFlags.Static | BindingFlags.IgnoreCase
			);

			if (propertyInfo == null)
			{
				throw new Exception("Type '{0}' does not have public property named '{1}'.".FormatWith(
					/*0*/ type.FullName, /*1*/ propertyName
				));
			}

			return instance.GetPropertyValue(propertyInfo);
		}

		public static T GetPropertyValue<T>(this object instance, PropertyInfo propertyInfo)
		{
			return (T)GetPropertyValue(instance, propertyInfo);
		}

		/// <summary>
		/// Get the property value of the object. Throws an exception if the property value can not be read
		/// </summary>
		public static object GetPropertyValue(this object instance, PropertyInfo propertyInfo)
		{
			#region Preconditions

			if (instance == null)
				throw new ArgumentNullException("instance");

			if (propertyInfo == null)
				throw new ArgumentNullException("propertyInfo");

			if (!propertyInfo.CanRead)
				throw new Exception("property is not readable");

			#endregion

			return propertyInfo.GetValue(instance, null);
		}
	}
}