namespace Carbon.Reflection
{
	using System;
	using System.Reflection;

	public static class ReflectionHelper
	{
		public static Type[] GetTypesFromArgs(object[] args)
		{
			var types = new Type[args.Length];

			for (int i = 0; i < args.Length; i++)
			{
				types[i] = args[i].GetType();
			}

			return types;
		}
	}
}