namespace Carbon.Logging
{
	using System;

	public class ConsoleLogger : ILogger
	{
		private readonly string name;

		public ConsoleLogger() { }

		public ConsoleLogger(string name) {
			this.name = name;
		}

		public void Debug(string message)
		{
			Log(LogLevel.Debug, message);
		}

		public void Error(string message)
		{
			Log(LogLevel.Error, message, null);
		}

		public void Error(string message, Exception ex)
		{
			Log(LogLevel.Error, message, ex);
		}

		public void Fatal(string message, Exception ex)
		{
			Log(LogLevel.Fatal, message, ex);
		}

		public void Info(string message)
		{
			Log(LogLevel.Info, message);
		}

		public void Warn(string message)
		{
			Log(LogLevel.Warn, message);
		}

		private void Log(LogLevel level, string message, Exception exception = null)
		{
			if (exception != null)
			{
				string exceptionType = exception.GetType().FullName;

				Console.Out.WriteLine("[{0}] '{1}' {2}: {3} {4}",
					level.ToString(), this.name, exceptionType, exception.Message, exception.StackTrace
				);
			}
			else
			{
				Console.Out.WriteLine("[{0}] '{1}' {2}", level, this.name, message);
			}
		}

		public ILogger CreateChild(string loggerName)
		{
			#region Preconditions

			if (loggerName == null)
				throw new ArgumentNullException("loggerName");

			#endregion

			return new ConsoleLogger(string.Format("{0}.{1}", this.name, loggerName));
		}
	}
}
