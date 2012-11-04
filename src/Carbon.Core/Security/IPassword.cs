namespace Carbon.Security
{
	public interface IPassword
	{
		int Version { get; }

		byte[] Hash { get; }

		byte[] Salt { get; }
	}
}