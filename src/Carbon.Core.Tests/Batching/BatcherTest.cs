namespace Carbon.Controls.Tests
{
	using System;
	using System.Linq;

	using NUnit.Framework;

	[TestFixture]
	public class BatcherTest
	{
		[Test]
		public void BatchCounts() 
		{
			Assert.AreEqual(10, new Batcher(10, 100).BatchCount);
			Assert.AreEqual(20, new Batcher(5, 97).BatchCount);
		}

		[Test]
		public void BatchOffset()
		{
			var batcher = new Batcher(10, 99);

			var firstBatch = batcher.Batches.First();

			Assert.AreEqual(0, firstBatch.Index);
			Assert.AreEqual(0, firstBatch.Skip);
			Assert.AreEqual(10, firstBatch.Take);

			var lastBatch = batcher.Batches.Last();

			Assert.AreEqual(9, lastBatch.Index);
			Assert.AreEqual(90, lastBatch.Skip);
			Assert.AreEqual(10, lastBatch.Take);
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