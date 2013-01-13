namespace Carbon
{
	using System;

	public class SystemClock : IClock
	{
		public DateTime Observe()
		{
			return DateTime.UtcNow;
		}
	}
}