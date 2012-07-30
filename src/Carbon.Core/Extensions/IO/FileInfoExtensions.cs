namespace Carbon.Helpers
{
	using System.IO;

	using Carbon.Media;

	public static class FileInfoExtensions
	{
		public static string GetMimeType(this FileInfo file)
		{
			return Mime.FromFileExtension(file.Extension);
		}

		public static string ReadAllText(this FileInfo file) 
		{
			using (var reader = file.OpenText()) 
			{
				return reader.ReadToEnd();
			}
		}
	}
}