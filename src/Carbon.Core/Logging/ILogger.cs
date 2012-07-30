namespace Carbon.Logging
{
	using System;

	public interface ILogger
	{
		void Debug(string message);

		void Error(string message);

		void Error(string message, Exception ex);

		void Fatal(string message, Exception ex);

		void Info(string message);

		void Warn(string message);

		ILogger CreateChild(string name);
	}
}