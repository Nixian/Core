namespace Carbon.Helpers.Tests
{
	using System;

	using NUnit.Framework;

	[TestFixture]
	public class EnumHelperTests
	{
		[Test]
		public void One()
		{
			var items = EnumHelper.GetItems<int>(typeof(Things));

			Assert.AreEqual("Apple", items[0].Name);
			Assert.AreEqual(1, items[0].Value);

			Assert.AreEqual(3, items.Count);
		}
	}

	public enum Things
	{
		Apple = 1,
		House,
		Car
	}
}