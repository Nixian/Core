namespace Carbon.Validation.Tests
{
	using System;
	using System.IO;
	using System.Runtime.Serialization.Formatters.Binary;

	using NUnit.Framework;

	[TestFixture]
	public class ValidationErrorCollectionTests
	{
		[Test]
		public void SerializeTest()
		{
			var errors = new ValidationErrorCollection();

			errors.Add("key", "error 1");
			errors.Add("error 2");

			var formatter = new BinaryFormatter();

			using (var stream = new MemoryStream())
			{
				formatter.Serialize(stream, errors);

				var data = Convert.ToBase64String(stream.ToArray());

				stream.Position = 0;

				var errors2 = (ValidationErrorCollection)formatter.Deserialize(stream);

				Assert.AreEqual(2, errors2.Count);
				Assert.AreEqual("error 1", errors2[0].Message);
				Assert.AreEqual("key", errors2[0].Key);
				Assert.AreEqual("error 2", errors2[1].Message);
			}
		}
	}
}
