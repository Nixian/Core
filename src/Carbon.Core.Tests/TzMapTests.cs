namespace Carbon.Helpers.Tests
{
	using System;
	using System.Linq;

	using NUnit.Framework;

	[TestFixture]
	public class TZMapTests
	{
		[Test]
		public void SystemTests2()
		{
			foreach (var item in TZMap.Items)
			{
				var tz = TZMap.GetTimeZoneInfo(item.Key);

				Assert.AreNotEqual(null, tz);
			}
		}

		[Test]
		public void Len()
		{
			// Ensure we don't have any timezones over 20 characters
			Assert.AreNotEqual(20, TZMap.Items.Max(item => item.Key.Length).ToString());
		}


		[Test]
		public void SystemTests()
		{
			Assert.AreEqual(-5.Hours(), TZMap.GetTimeZoneInfo("America/New_York").BaseUtcOffset);
			Assert.AreEqual(-6.Hours(), TZMap.GetTimeZoneInfo("America/Chicago").BaseUtcOffset);
		}

		[Test]
		public void MapTests()
		{
			Assert.AreEqual("Central Standard Time", TZMap.GetSystemId("America/Chicago"));
			Assert.AreEqual("Mountain Standard Time", TZMap.GetSystemId("America/Denver"));
			Assert.AreEqual("Pacific Standard Time", TZMap.GetSystemId("America/Los_Angeles"));
			Assert.AreEqual("Eastern Standard Time", TZMap.GetSystemId("America/New_York"));
		}

		/*
		[Test]
		public void TEST()
		{
			foreach (var item in TZMap.MapImport().OrderBy(i => i.StandardName))
			{
				// { "America/Chicago",		"Central Standard Time" },
				Console.WriteLine("{{ \"{0}\", \"{1}\" }},".FormatWith(item.StandardName, item.WindowsName));
			}
		}
		*/
	}
}
