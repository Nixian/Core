namespace Carbon.Helpers
{
	using System;
	using System.Collections.Generic;
	using System.Linq;

	public static class EnumHelper
	{
		public static IList<EnumItem<T>> GetItems<T>(Type type)
		{
			#region Preconditions

			if (type == null) 
				throw new ArgumentNullException("type");

			if (!type.IsEnum)
				throw new ArgumentException("Must be an Enum", paramName: "type");

			#endregion

			var names = Enum.GetNames(type);
			var values = new List<T>();

			foreach (var o in Enum.GetValues(type))
			{
				values.Add((T)o);
			}

			return names.Zip(values, (name, value) => new EnumItem<T>(name, (T)value)).ToArray();
		}

		public class EnumItem<T>
		{
			private readonly string name;
			private readonly T value;

			public EnumItem(string name, T value)
			{
				this.name = name;
				this.value = value;
			}

			public string Name 
			{
				get { return name; }
			}

			public T Value
			{
				get { return value; }
			}
		}
	}
}
