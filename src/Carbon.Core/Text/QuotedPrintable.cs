namespace Carbon.Helpers
{
	using System.Net.Mail;

	public static class QuotedPrintable
	{
		public static string Decode(string text)
		{
            var attachment = Attachment.CreateAttachmentFromString("", text);

			return attachment.Name;
		}
	}
}
