namespace Carbon.Helpers
{
	using System.IO;
	using System.Net;
	using System.Threading.Tasks;

	public static class WebRequestExtensions
	{
		public static Task<Stream> GetRequestStreamAsync(this WebRequest request)
		{
			return Task.Factory.FromAsync<Stream>(request.BeginGetRequestStream, request.EndGetRequestStream, null);
		}

		public static Task<WebResponse> GetReponseAsync(this WebRequest request)
		{
			return Task.Factory.FromAsync<WebResponse>(request.BeginGetResponse, request.EndGetResponse, null);
		}
	}
}
