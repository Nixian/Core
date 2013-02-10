namespace Carbon.Geometry.Tests
{
	using NUnit.Framework;

	[TestFixture]
	public class PointTests
	{
		[Test]
		public void PointEqualityTests()
		{
			Assert.AreEqual(new Point(0, 0), new Point(0, 0));
			Assert.AreNotEqual(new Point(0, 0), new Point(0, 1));

			Assert.IsTrue(new Point(0, 0) == new Point(0, 0));
			Assert.IsTrue(new Point(1, 0) == new Point(1, 0));
			Assert.IsTrue(new Point(0, 1) == new Point(0, 1));
			Assert.IsTrue(new Point(25.942, 1.3) == new Point(25.942, 1.3));

			Assert.IsFalse(new Point(0, 0) != new Point(0, 0));
			Assert.IsFalse(new Point(0, 0) != new Point(0, 0));
			Assert.IsFalse(new Point(0, 0) != new Point(0, 0));
			Assert.IsFalse(new Point(0, 0) != new Point(0, 0));

			Assert.IsFalse(new Point(0, 0) == new Point(1, 0));
		}

		[Test]
		public void PointMultiplyTests()
		{
			Assert.AreEqual(new Point(2, 2), (new Point(1, 1) * 2));
		}
	}
}
