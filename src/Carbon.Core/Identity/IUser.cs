namespace Carbon.Models
{
	using System.Security.Principal;

	using Carbon.Data;

	public interface IUser : IAgent, IIdentity
	{
		IMembership GetMembership(IContainer organization);
	}
}