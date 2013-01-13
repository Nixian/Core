namespace Carbon.Security
{
	public interface IPassword
	{
		int Version { get; }

		/// <summary>
		/// Derived from the original password and salt
		/// </summary>
		byte[] Key { get; }

		byte[] Salt { get; }
	}
}