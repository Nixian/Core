namespace Carbon.Controls.Tests
{
	using System;
	using System.Linq;

	using NUnit.Framework;

	[TestFixture]
	public class BatcherTest
	{
		[Test]
		public void BatchCounts() {
			Assert.AreEqual(10, new Batcher(10, 100).BatchCount);
			Assert.AreEqual(20, new Batcher(5, 97).BatchCount);
		}

		[Test]
		public void BatchOffset()
		{
			var batcher = new Batcher(10, 99);

			var firstBatch = batcher.Batches.First();

			Assert.AreEqual(1, firstBatch.Number);
			Assert.AreEqual(0, firstBatch.Offset);
			Assert.AreEqual(10, firstBatch.Limit);

			var lastBatch = batcher.Batches.Last();

			Assert.AreEqual(10, lastBatch.Number);
			Assert.AreEqual(90, lastBatch.Offset);
			Assert.AreEqual(10, lastBatch.Limit);
		}

		/*
		[Test]
		public void BatchOffset2()
		{
			var batcher = new Batcher(10, 99);

			var offsettedBatches = batcher.GetBatches(5);

			Assert.AreEqual(6, offsettedBatches.Count);

			var firstOffsettedBatch = offsettedBatches[0];

			Assert.AreEqual(5, firstOffsettedBatch.Number);
			Assert.AreEqual(40, firstOffsettedBatch.Offset);
			Assert.AreEqual(10, firstOffsettedBatch.Limit);
		}
		*/
	}
}