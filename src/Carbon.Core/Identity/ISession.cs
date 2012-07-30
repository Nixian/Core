namespace Carbon.Security
{
	using System;

	public interface ISession
	{
		int Id { get; }

		DateTime Created { get; }
		DateTime Expires { get; }
	}
}