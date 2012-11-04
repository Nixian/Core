namespace Carbon.Reflection
{
	using System;
	using System.Reflection;

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

			var property = type.GetProperty(propertyName, BindingFlags.Instance | BindingFlags.Public);

			if (property == null)
			{
				throw new Exception(string.Format("The type '{0}' does not have a property named '{1}'.",
					/*0*/ type.FullName, /*1*/ propertyName
				));
			}

			return instance.GetPropertyValue(property);
		}

		public static T GetPropertyValue<T>(this object instance, PropertyInfo propertyInfo)
		{
			return (T)GetPropertyValue(instance, propertyInfo);
		}

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