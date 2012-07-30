namespace Carbon.Models
{
	public interface IUserDetails
	{
		string Name { get; }

		string Email { get; }
		
		string Password { get; }
	}
}