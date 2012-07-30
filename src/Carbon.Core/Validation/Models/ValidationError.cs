namespace Carbon.Validation
{
	using System;

	public class ValidationError
	{
		private readonly string key;
		private readonly string message;
		private readonly string description;

		public ValidationError(string message)
			: this(null, message) { }

		public ValidationError(string key, string message, string description = null)
		{
			this.key = key;
			this.message = message;
			this.description = description;
		}

		public string Key 
		{
			get { return key; }
		}

		public string Message {
			get { return message; }
		}

		public string Description
		{
			get { return description; }
		}

		public override string ToString() 
		{
			return message;
		}
	}
}