namespace Carbon.Security
{
	using Carbon.Data;

	public interface IAuthorizable
	{
		IContainer Owner { get; }

		// TODO: Change to an ACL

		// IPolicy
	}

	// TODO:
	// - GetPolicy()
}

/* 
TODO ---------------------
- Move to Carbon.Security
*/