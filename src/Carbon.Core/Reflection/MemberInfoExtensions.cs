namespace Carbon.Reflection
{
	using System;
	using System.Reflection;

	using Carbon.Helpers;

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

			if (member == null)
				throw new ArgumentNullException("member");

			#endregion

			var attributes = member.GetCustomAttributes(typeof(T), false);

			if (attributes.Length == 0) return null;

			return attributes[0] as T;
		}

		public static object GetValue(this MemberInfo member, object instance)
		{
			#region Preconditions

			if (instance == null)
				throw new ArgumentNullException("instance");

			if (member == null)
				throw new ArgumentNullException("member");

			#endregion

			switch (member.MemberType)
			{
				case MemberTypes.Field: return ((FieldInfo)member).GetValue(instance);
				case MemberTypes.Property:
				{
					try
					{
						return ((PropertyInfo)member).GetValue(instance, null);
					}
					catch (TargetParameterCountException e) {
						throw new ArgumentException(
							message:		"MemberInfo '{0}' expected an index paramater".FormatWith(member.Name),
							paramName:		"member",
							innerException: e
						);
					}
					catch (Exception ex)
					{
						throw new Exception("Could not read member '{0}'".FormatWith(member.Name, ex));
					}
				}
				default:
				{
					throw new ArgumentException(
						message:	"Unexpected MemberType".FormatWith(member.Name),
						paramName:	"member"
					);
				}
			}
		}		
	}
}
