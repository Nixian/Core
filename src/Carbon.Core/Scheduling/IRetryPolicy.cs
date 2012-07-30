namespace Carbon.Scheduling
{
	using System;

	// TODO: Move into Carbon.Data

	public interface IRetryPolicy 
	{
		bool ShouldRetry(int retryCount);

		TimeSpan CalculateDelay(int retryCount);
	}
}