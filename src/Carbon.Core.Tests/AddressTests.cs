namespace Carbon.Models.Tests
{
	using System.Linq;

	using NUnit.Framework;

	public class AddressTests
	{
		[Test]
		public void ToLines()
		{
			var address = new Address
			{
				Line1 = "582 Market Street",
				Line2 = "Suite 1115",
				City = "San Francisco",
				Region = "CA",
				PostalCode = "94104",
				Country = "United States"
			};

			var lines = address.ToLines().ToArray();

			/*
			582 Market Street
			Suite 1115
			San Francisco, CA 94104
			United States
			*/

			Assert.AreEqual(4, lines.Length);
			Assert.AreEqual("582 Market Street", lines[0]);
			Assert.AreEqual("Suite 1115", lines[1]);
			Assert.AreEqual("San Francisco, CA 94104", lines[2]);
			Assert.AreEqual("United States", lines[3]);

			Assert.AreEqual(
@"582 Market Street<br />
Suite 1115<br />
San Francisco, CA 94104<br />
United States", address.ToHtml());

		}

		public class Address : IAddress
		{
			public string Line1 { get; set; }

			public string Line2 { get; set; }

			public string City { get; set; }

			public string Region { get; set; }

			public string PostalCode { get; set; }

			public string Country { get; set; }

		}
	}
}