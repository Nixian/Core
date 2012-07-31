namespace Carbon.Reflection.Tests
{
	using System;
	using System.Drawing;
	using System.Linq;
	using System.Reflection;

	using NUnit.Framework;

	using Carbon.Helpers;
	using Carbon.Security;

	[TestFixture]
	public class ReflectionTests
	{
		[Test]
		public void GetPropertyValueTest()
		{
			var orange = new Orange { 
				Name = "Orange", 
				Calories = 100
			};

			Assert.AreEqual("Orange", orange.GetPropertyValue<string>("name"));
			Assert.AreEqual(Color.Orange, orange.GetPropertyValue<Color>("Color"));
			Assert.AreEqual(100, orange.GetPropertyValue("Calories"));
			Assert.AreEqual(false, orange.GetPropertyValue<bool>("IsEaten"));

			orange.Eat();

			Assert.AreEqual(true, orange.GetPropertyValue<bool>("IsEaten"));
		}

		[Test]
		public void GetFirstCustomAttributeTest()
		{
			var type = typeof(Orange);

			Assert.IsTrue(type.GetProperty("Name").HasCustomAttribute<SanitizeAttribute>());
			Assert.IsTrue(type.GetProperty("Name").GetFirstCustomAttribute<SanitizeAttribute>().AllowHtml);
		}
	}

	public class Fruit
	{
		[Sanitize(AllowHtml = true)]
		public string Name { get; set; }

		public int Calories { get; set; }
	}

	public class Orange : Fruit
	{
		bool isEaten = false;

		public Color Color {
			get { return Color.Orange; }
		}

		public bool IsEaten {
			get { return isEaten; }
		}

		public void Eat() {
			isEaten = true;
		}
	}
}