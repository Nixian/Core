namespace Carbon.Helpers
{
	using System;
	using System.IO;

	public static class StreamExtensions
	{
		public static void WriteToFile(this Stream inputStream, string filePath, bool overWrite = false)
		{
			#region Preconditions

			if (inputStream == null)
				throw new ArgumentNullException("inputStream");

			if (filePath == null)
				throw new ArgumentException("filePath");

			#endregion

			if (!overWrite)
			{
				if (File.Exists(filePath)) 
				{
					throw new Exception("File already exists");
				}
			}

			// Ensure the directory exists
			IOHelper.TryCreateDirectory(filePath);

			using (var writeStream = new FileStream(filePath, FileMode.Create))
			{
				inputStream.CopyTo(writeStream);

				writeStream.Flush();
			}
		}

		public static string ReadString(this Stream stream)
		{
			#region Preconditions

			if (stream == null)
				throw new ArgumentNullException("stream");

			if (!stream.CanRead)
				throw new ArgumentException("Must be true", paramName: "stream.CanRead");

			#endregion

			// Make sure we're at the begining
			if (stream.CanSeek && stream.Position != 0)
			{
				stream.Position = 0;
			}

			using (var reader = new StreamReader(stream))
			{
				return reader.ReadToEnd();
			}
		}

		public static byte[] ReadFully(this Stream inputStream)
		{
			#region Preconditions

			if (inputStream == null)
				throw new ArgumentNullException("inputStream");

			#endregion

			using (var tempStream = new MemoryStream())
			{
				inputStream.CopyTo(tempStream);

				return tempStream.ToArray();
			}
		}
	}
}
