namespace Carbon.Security
{
	using System;
	using System.Security.Principal;

	[Serializable]
	public class Principal : IPrincipal
	{
		private readonly IIdentity identity;
		private readonly string[] roles;

		public Principal(IIdentity identity) 
			: this(identity, null) { }

		public Principal(IIdentity identity, string[] roles)
		{
			this.identity = identity;
			this.roles = roles;
		}

		public IIdentity Identity 
		{
			get { return identity; }
		}

		public bool IsInRole(string role)
		{
			if (roles == null) 
			{
				return false;
			}

			return Array.BinarySearch(roles, role) >= 0 ? true : false;
		}
	}
}