namespace Carbon.Scheduling
{
	using System;

	// TODO: Move into Carbon.Data

	public class ExponentialBackoffRetryPolicy : IRetryPolicy
	{
		private readonly TimeSpan initialDelay;
		private readonly TimeSpan maxDelay;
		private readonly int maxRetries;

		public ExponentialBackoffRetryPolicy(TimeSpan initialDelay, TimeSpan maxDelay)
			: this(initialDelay, maxDelay, -1) { }

		public ExponentialBackoffRetryPolicy(TimeSpan initialDelay, TimeSpan maxDelay, int maxRetries) {
			this.initialDelay = initialDelay;
			this.maxDelay = maxDelay;
			this.maxRetries = maxRetries;
		}

		public bool ShouldRetry(int retryCount) {
			return maxRetries == -1 || maxRetries > retryCount;
		}

		public TimeSpan CalculateDelay(int retryCount)
		{
			// R = A random number between 1 and 2
			// T = The initial timeout
			// F = The exponential factor (2)
			// N = Number of retries so far
			// M = Max Delay
			// delay = MIN( R * T * F ^ N , M )

			long exponentialDelay = (long)((double)initialDelay.Ticks * Math.Pow(retryCount, 2));

			long ticks = Math.Min(maxDelay.Ticks, exponentialDelay);

			return TimeSpan.FromTicks(ticks);
		}
	}
}