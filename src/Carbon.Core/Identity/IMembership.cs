namespace Carbon.Models
{
	using System;

	public interface IMembership
	{
		/// <summary>
		/// The provider of the membership
		/// </summary>
		IAgent Source { get; }

		IAgent Target { get; }

		string[] Roles { get; }
	}
}