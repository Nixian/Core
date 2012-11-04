namespace Carbon.Parsing
{
	using System;
	using System.IO;

	using Carbon.Helpers;

	public class SourceReader : IDisposable
	{
		public const char EofChar = '\0';

		private readonly TextReader textReader;
		private char current;
		private bool isDisposed = false;
		private int position;

		public SourceReader(string text)
			: this(new StringReader(text)) { }

		public SourceReader(TextReader textReader)
		{
			this.textReader = textReader;
		}

		public char Current 
		{
			get { return current; }
		}

		public bool IsEof 
		{
			get { return current == EofChar; }
		}

		public int Position
		{
			get { return position; }
		}

		public char Peek()
		{
			int charCode = textReader.Peek();

			return (charCode > 0) ? (char)charCode : EofChar;
		}

		/// <summary>
		/// Advances to the next character
		/// </summary>
		public void Next() 
		{
			if (marked != -1 && (marked <= this.position) && !IsEof)
			{
				buffer.Append(current);
			}

			int charCode = textReader.Read(); // -1 if there are no more chars to read (e.g. stream has ended)

			this.current = (charCode > 0) ? (char)charCode : EofChar;

			position++;
		}

		public void SkipWhitespace() 
		{
			while (current.IsWhiteSpace()) 
			{
				Next();
			}
		}

		#region Mark

		private readonly StringBuffer buffer = new StringBuffer();

		private int marked = -1;

		public void Mark(bool appendCurrent = true)
		{
			marked = this.position;

			if (appendCurrent == false)
				marked++;
	
		}

		public string Unmark()
		{
			marked = -1;

			return buffer.Extract();
		}

		#endregion

		#region IDisposable

		public void Dispose()
		{
			if (isDisposed) return;

			textReader.Dispose();

			isDisposed = true;
		}

		#endregion
	}
}
