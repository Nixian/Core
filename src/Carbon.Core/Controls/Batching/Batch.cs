namespace Carbon.Controls
{
	public sealed class Batch
	{
		private readonly int index;
		private readonly int skip;	// offset
		private readonly int take; // limit

		public Batch(int index, int skip, int take) 
		{
			this.index = index;
			this.skip = skip;
			this.take = take;
		}

		public int Index
		{
			get { return index; }
		}

		public int Skip 
		{
			get { return skip; }
		}

		public int Take 
		{
			get { return take; }
		}
	}
}
