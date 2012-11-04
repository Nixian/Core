namespace Carbon.Models
{
	using System.Security.Principal;

	using Carbon.Data;
	using Carbon.Security;

	public interface IUser : IAgent, IIdentity
	{
		IPassword Password { get; }

		IMembership GetMembership(IContainer organization);
	}
}