namespace Carbon.Controls
{
	using System;
	using System.Collections;
	using System.Collections.Generic;

	public sealed class Batcher : IEnumerable<Batch>
	{
		private readonly int batchSize;
		private readonly int itemCount;

		public Batcher(int batchSize, int itemCount)
		{
			#region Preconditions

			if (batchSize <= 0)
			{
				throw new ArgumentOutOfRangeException(
					paramName:		"batchSize",
					actualValue:	batchSize,
					message:		"Must be greater than 0"
				);
			}

			#endregion

			this.batchSize = batchSize;
			this.itemCount = itemCount;
		}

		public int BatchCount
		{
			get
			{
				// Count the whole bacthes
				int batchCount = itemCount / batchSize;

				// Add 1 if there's a remaining partial batch
				if (itemCount % batchSize > 0) {
					batchCount++;
				}

				return batchCount;
			}
		}

		public int BatchSize 
		{
			get { return batchSize; }
		}

		public int ItemCount 
		{
			get { return itemCount; }
		}

		public IEnumerable<Batch> Batches
		{
			get
			{
				for (int i = 0; i < BatchCount; i++)
				{
					yield return new Batch(
						index: i,
						skip: i * batchSize,
						take: (itemCount < batchSize * i) ? itemCount : batchSize
					);
				}
			}
		}

		#region IEnumerator<Batch>

		IEnumerator<Batch> IEnumerable<Batch>.GetEnumerator()
		{
			return Batches.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return Batches.GetEnumerator();
		}

		#endregion
	}
}
