namespace Carbon.Controls
{
	using System;
	using System.Collections.Generic;
	using System.Linq;

	public class Batcher
	{
		private readonly int itemsPerBatch;
		private readonly int itemCount;

		public Batcher(int itemsPerBatch, int itemCount)
		{
			#region Preconditions

			if (itemsPerBatch <= 0)
				throw new ArgumentOutOfRangeException(
					/*paramName*/ "itemsPerBatch",
					/*actualValue*/ itemsPerBatch,
					/*message*/ "itemsPerBatch must be greater than 0"
				);

			#endregion

			this.itemsPerBatch = itemsPerBatch;
			this.itemCount = itemCount;
		}

		public int BatchCount
		{
			get
			{
				// Count the whole bacthes
				int batchCount = itemCount / itemsPerBatch;

				// Add 1 if there's a remaining partial batch
				if (itemCount % itemsPerBatch > 0) {
					batchCount++;
				}

				return batchCount;
			}
		}

		public int ItemsPerBatch {
			get { return itemsPerBatch; }
		}

		public int ItemCount {
			get { return itemCount; }
		}

		public IEnumerable<Batch> Batches
		{
			get
			{
				for (int i = 0; i < BatchCount; i++)
				{
					yield return new Batch(
						number: i + 1,
						offset: i * itemsPerBatch,
						limit: (itemCount < itemsPerBatch * i) ? itemCount : itemsPerBatch
					);
				}
			}
		}
	}
}
