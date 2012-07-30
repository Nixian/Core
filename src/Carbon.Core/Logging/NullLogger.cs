namespace Carbon.Logging
{
	using System;

	public class NullLogger : ILogger
	{
		public static readonly NullLogger Instance = new NullLogger();

		public void Debug(string message) { }

		public void Error(string message) { }

		public void Error(string message, Exception ex) { }

		public void Fatal(string message, Exception ex) { }

		public void Info(string message) { }

		public void Warn(string message) { }

		public ILogger CreateChild(string loggerName)
		{
			return Instance;
		}
	}
}