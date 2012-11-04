namespace Carbon.Reflection
{
	using System;
	using System.Reflection;

	public static class MemberInfoExtensions
	{
		public static bool HasCustomAttribute<T>(this MemberInfo member) 
			where T : Attribute
		{
			return member.IsDefined(typeof(T), true);
		}

		public static T GetFirstCustomAttribute<T>(this MemberInfo member) 
			where T : Attribute
		{
			#region Preconditions

			if (member == null) throw new ArgumentNullException("member");

			#endregion

			var attributes = member.GetCustomAttributes(typeof(T), false);

			if (attributes.Length == 0) return null;

			return attributes[0] as T;
		}
	}
}
