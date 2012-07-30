namespace Carbon.Security
{
	using System;

	public interface IPassword
	{
		Int16 Version { get; }

		string Hash { get; }
	}
}