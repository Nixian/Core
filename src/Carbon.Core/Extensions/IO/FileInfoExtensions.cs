namespace Carbon.Helpers
{
	using System.IO;

	public static class FileInfoExtensions
	{
		/*
		public static string GetMimeType(this FileInfo file)
		{
			return Mime.FromExtension(file.Extension);
		}
		*/

		public static string ReadAllText(this FileInfo file) 
		{
			using (var reader = file.OpenText()) 
			{
				return reader.ReadToEnd();
			}
		}
	}
}