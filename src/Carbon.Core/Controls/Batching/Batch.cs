namespace Carbon.Controls
{
	public class Batch
	{
		private readonly int number;
		private readonly int offset;
		private readonly int limit;

		public Batch(int number, int offset, int limit) 
		{
			this.number = number;
			this.offset = offset;
			this.limit = limit;
		}

		public int Number
		{
			get { return number; }
		}

		public int Offset 
		{
			get { return offset; }
		}

		public int Limit 
		{
			get { return limit; }
		}

		public int FirstItem 
		{
			get { return offset + 1; }
		}
	}
}
