namespace Carbon
{
	using System;

	public interface IClock
	{
		DateTime Observe();
	}
}