namespace Carbon.Models
{
	public interface IAddress
	{
		string Line1 { get; }

		string Line2 { get; }

		string City { get; }

		string Region { get; }

		string PostalCode { get; }

		string Country { get; }
	}
}

// TODO:
// - Change Country to CountryCode or CountryName