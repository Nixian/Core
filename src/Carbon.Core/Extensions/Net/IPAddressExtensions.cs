﻿namespace Carbon.Helpers
{
	using System.Net;

	public static class IPAddressExtensions
	{
		public static bool CanResolve(this IPAddress ip)
		{
			try { string hostEntry = Dns.GetHostEntry(ip).HostName; }
			catch { return false; }

			return true;
		}
	}
}