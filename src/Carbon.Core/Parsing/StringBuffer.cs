namespace Carbon.Parsing
{
	using System.Text;

	public class StringBuffer
	{
		private readonly StringBuilder sb = new StringBuilder();

		public int Length
		{
			get { return sb.Length; }
		}

		public void Append(char c) 
		{
			sb.Append(c);
		}

		public string Extract() 
		{
			var value = sb.ToString();

			Reset();

			return value;
		}

		public void Reset() 
		{
			sb.Clear();
		}
	}
}
