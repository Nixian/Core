namespace Carbon.Models.Tests
{
	using System;

	using NUnit.Framework;

	[TestFixture]
	public class WeightTest
	{
		[Test]
		public void PoundTest()
		{
			var weight = Weight.FromPounds(10);

			var poundsAndOunces = weight.ToPoundsAndOunces();

			Assert.AreEqual(10d, weight.Value);
			Assert.AreEqual(10, poundsAndOunces.Pounds);
			Assert.AreEqual(0, poundsAndOunces.Ounces);

			Console.WriteLine(weight.ToKilograms().Value);

			Assert.AreEqual(4.5359237d, Math.Round(weight.ToKilograms().Value, 7));
		}

		[Test]
		public void HalfPoundToWholePoundsAndOunces()
		{
			var weight = Weight.FromPounds(0.5d);

			var poundsAndOunces = weight.ToPoundsAndOunces();

			Assert.AreEqual(0.5d, weight.Value);
			Assert.AreEqual(0, poundsAndOunces.Pounds);
			Assert.AreEqual(8, poundsAndOunces.Ounces);
		}

		[Test]
		public void FromKilogramsTests()
		{
			var weight = Weight.FromKilograms(11.5);

			Assert.AreEqual(MeasurementUnit.Kilogram, weight.Unit);

			Assert.AreEqual(25.3531602D, Math.Round(weight.ToPounds().Value, 7));
		}
	}
}