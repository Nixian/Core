namespace Carbon.Helpers
{
	using System;
	using System.Net;

	public static class WebResponseExtensions
	{
		public static string ReadResponseText(this WebResponse webResponse)
		{
			#region Preconditions

			if (webResponse == null)
				throw new ArgumentNullException("webResponse");

			#endregion

			using (var responseStream = webResponse.GetResponseStream())
			{
				if (responseStream == null) {
					return null;
				}

				return responseStream.ReadString();
			}
		}
	}
}