namespace Carbon.Helpers
{
	using System;

	public static class Int32Extensions
	{
		public static TimeSpan Milliseconds(this Int32 self) 
		{
			return TimeSpan.FromMilliseconds(self);
		}

		public static TimeSpan Second(this Int32 self) 
		{
			return TimeSpan.FromSeconds(self);
		}

		public static TimeSpan Seconds(this Int32 self) 
		{
			return TimeSpan.FromSeconds(self);
		}

		public static TimeSpan Minute(this Int32 self) 
		{
			return TimeSpan.FromMinutes(self);
		}

		public static TimeSpan Minutes(this Int32 self)
		{
			return TimeSpan.FromMinutes(self);
		}

		public static TimeSpan Hours(this Int32 self) 
		{
			return TimeSpan.FromHours(self);
		}

		public static TimeSpan Day(this Int32 self) 
		{
			return TimeSpan.FromDays(self);
		}

		public static TimeSpan Days(this Int32 self) 
		{
			return TimeSpan.FromDays(self);
		}

		public static void Times(this Int32 self, Action<int> action)
		{
			for (int i = 0; i < self; i++) 
			{
				action(i);
			}
		}

		public static bool InRange(this Int32 self, Int32 min, Int32 max) 
		{
			return self >= min && self <= max;
		}
	}
}