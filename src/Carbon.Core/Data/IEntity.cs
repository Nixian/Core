namespace Carbon.Data
{
	public interface IEntity 
	{
		int Id { get; }

		int Version { get; }
	}
}