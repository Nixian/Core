namespace Carbon.Security
{
	using System;

	[AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
	public class SanitizeAttribute : Attribute 
	{
		public bool AllowHtml { get; set; }

		/// <summary>
		/// TODO: Disable scripts by default
		/// </summary>
		public bool AllowScripts { get; set; }

		// rel="nofollow"
		public bool AddNoFollowsToLinks { get; set; }

		/// <summary>
		/// Trim leading and trailing space?
		/// </summary>
		public bool Trim { get; set; }
	}
}