namespace Carbon.Models
{
	using System.Security.Principal;

	using Carbon.Data;
	using Carbon.Security;

	public interface IUser : IIdentity
	{
		int Id { get; }

		IPassword Password { get; }

		bool IsMemberOf(IContainer organization);

		bool IsMemberOfWithRole(IContainer organization, string roleName);
	}
}