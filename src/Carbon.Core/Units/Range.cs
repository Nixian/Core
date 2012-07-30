namespace Carbon
{
	public struct Range<T> : IRange<T>
	{
		private readonly T start;
		private readonly T end;

		public Range(T start, T end)
		{
			this.start = start;
			this.end = end;
		}

		public T Start
		{
			get { return start; }
		}

		public T End
		{
			get { return end; }
		}
	}
}
