namespace Carbon.Helpers
{
	public static class FloatExtensions
	{
		public static bool InRange(this float self, float min, float max) 
		{
			return self >= min && self <= max;
		}
	}
}