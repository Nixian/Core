namespace Carbon.Scheduling
{
	using System;
	using System.Threading;

	// TODO: Move into Carbon.Data

	public class PolicyScheduler
	{
		public const string ExceededMaximumRetryCount = "The action has exceeded the maxium number of retries for this policy.";

		private readonly IRetryPolicy retryPolicy;

		public PolicyScheduler(IRetryPolicy retryPolicy)
		{
			this.retryPolicy = retryPolicy;
		}

		public void Execute(Action action)
		{
			int retryCount = 0;

			Exception lastException;

			while(true)
			{
				try
				{
					action.Invoke();

					return;
				}
				catch (Exception ex)
				{
					lastException = ex;
					retryCount++;
				}

				if (retryPolicy.ShouldRetry(retryCount))
				{
					var timeToWait = retryPolicy.CalculateDelay(retryCount);

					Thread.Sleep(timeToWait);
				}
				else
				{
					throw new Exception(ExceededMaximumRetryCount, lastException);
				}
			}
		}
	}
}