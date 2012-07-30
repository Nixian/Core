namespace Carbon.Security
{
	using Carbon.Data;
	using Carbon.Models;

	public interface IAuthorizationService
	{
		bool AuthorizeAction(IUser user, IAuthorizable entity, Operation action);

		bool RequireRole(IUser user, IContainer space, string roleName);
	}
}

/* 
TODO ---------------------
- Move to Carbon.Security
*/