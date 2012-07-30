namespace Carbon
{
	using System;
	using System.Text;
	using System.IO;

	using Carbon.Helpers;
	using Carbon.Parsing;

	public struct Duration
	{
		private int years, months, weeks, days, hours, minutes;
		private float seconds;

		public int Years 
		{
			get { return years; }
			set { years = value; }
		}

		public int Months
		{
			get { return months; }
			set { months = value; }
		}

		public int Weeks
		{
			get { return weeks; }
			set { weeks = value; }
		}

		public int Days
		{
			get { return days; }
			set { days = value; }
		}

		public int Hours
		{
			get { return hours; }
			set { hours = value; }
		}

		public int Minutes
		{
			get { return minutes; }
			set { minutes = value; }
		}

		public float Seconds
		{
			get { return seconds; }
			set { seconds = value; }
		}

		public bool RequiresDelta
		{
			get { return (Months > 0 || Years > 0); }
		}

		public TimeSpan ToTimeSpan()
		{
			#region Preconditions

			if (RequiresDelta)
				throw new Exception("requires a start date to calculate time span");

			#endregion

			return new TimeSpan(
				/*days*/ days + (weeks * 7),
				/*hours*/ hours,
				/*minutes*/ minutes,
				/*seconds*/ (int)seconds
			);
		}

		public TimeUnit GetLargestUnit()
		{
 			if (Years > 0)		return TimeUnit.Year;
			if (Months > 0)		return TimeUnit.Month;
			if (Days > 0)		return TimeUnit.Day;
			if (Hours > 0)		return TimeUnit.Hour;
			if (Minutes > 0)	return TimeUnit.Hour;
			if (Seconds > 0)	return TimeUnit.Second;
			else				return TimeUnit.Tick;
		}

		public static Duration FromTimeSpan(TimeSpan timeSpan)
		{
			return new Duration {
				Days = timeSpan.Days,
				Hours = timeSpan.Hours,
				Minutes = timeSpan.Minutes,
				Seconds = (float)timeSpan.Seconds + ((float)timeSpan.Milliseconds / 1000f)
			};
		}

		public static Duration Parse(string text)
		{
			#region Preconditions

			if (text == null)
				throw new ArgumentNullException("text");

			if (text[0] != 'P')
				throw new ArgumentException("text must start with P");

			#endregion

			var duration = new Duration();

			var parser = new DurationParser(text);

			DurationParser.Token token;
			bool hasT = false;

			while ((token = parser.Next()) != null) {

				// Console.WriteLine("{0}:{1}", token.Label, token.Number);

				switch (token.Label) {
					case 'P': break;
					case 'Y': duration.Years = (int)token.Number;	break;
					case 'M':
						if (hasT)	
							duration.Minutes = (int)token.Number;
						else 		
							duration.Months = (int)token.Number;		
						
						break;

					case 'W': duration.Weeks = (int)token.Number;	break;
					case 'D': duration.Days = (int)token.Number;	break;
					case 'T': hasT = true;							break;
					case 'H': duration.Hours = (int)token.Number;	break;
					case 'S': duration.Seconds = token.Number;		break;
					
					default: throw new Exception("Invalid label '{0}'.".FormatWith(token.Label));
				}
			}

			return duration;
		}

		/// <summary>
		/// Iso 8601 formatted string
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			if (years == 0 && months == 0 && weeks == 0 && days == 0 
				&& hours == 0 && minutes == 0 && seconds == 0)
			{
				return "PT0S";
			}

			var sb = new StringBuilder();

			sb.Append("P");

			if (years > 0)	sb.AppendFormat("{0}Y", years);
			if (months > 0)	sb.AppendFormat("{0}M", months);
			if (weeks > 0)	sb.AppendFormat("{0}W", weeks);
			if (days > 0)	sb.AppendFormat("{0}D", days);

			if (hours > 0 || minutes > 0 || this.Seconds > 0)
			{
				sb.Append("T");

				if (hours> 0)		sb.AppendFormat("{0}H", hours);
				if (minutes > 0)	sb.AppendFormat("{0}M", minutes);
				if (seconds > 0) 	sb.AppendFormat("{0}S", seconds);
			}

			return sb.ToString();
		}

		public class DurationParser
		{
			private readonly SourceReader source;

			public DurationParser(string text)
			{
				#region Preconditions

				if (text == null)
					throw new ArgumentNullException("text");

				#endregion

				source = new SourceReader(text);

				source.Next(); // Start with the first char
			}

			public Token Next()
			{
				if (source.IsEof)
					return null;

				float number = 0;

				if (source.Current.IsNumber()) {
					number = ReadNumber();
				}
			
				char label = source.Current;

				source.Next();

				return new Token(label, number);
			}

			public float ReadNumber()
			{
				var sb = new StringBuilder();

				while (source.Current.IsNumber() || source.Current == '.')
				{
					sb.Append(source.Current);

					source.Next();
				}

				return sb.ToString().ToFloat();
			}

			public class Token
			{
				private readonly char label; // P & T are special
				private readonly float number;

				public Token(char label, float number) {
					this.label = label;
					this.number = number;
				}

				public char Label {
					get { return label; }
				}

				public float Number {
					get { return number; }
				}
			}
		}
	}
}

// Durations are represented by the format P[n]Y[n]M[n]DT[n]H[n]M[n]S or P[n]W as shown to the right.
// In these representations, the [n] is replaced by the value for each of the date and time elements that follow the [n]. 
// Leading zeros are not required, but the maximum number of digits for each element should be agreed to by the communicating parties. 
// The capital letters 'P', 'Y', 'M', 'W', 'D', 'T', 'H', 'M', and 'S' are designators for each of the date and time elements and are not replaced.

// * P is the duration designator (historically called "period") placed at the start of the duration representation.
// * Y is the year designator that follows the value for the number of years.
// * M is the month designator that follows the value for the number of months.
// * W is the week designator that follows the value for the number of weeks.
// * D is the day designator that follows the value for the number of days.
// * T is the time designator that precedes the time components of the representation.
// * H is the hour designator that follows the value for the number of hours.
// * M is the minute designator that follows the value for the number of minutes.
// * S is the second designator that follows the value for the number of seconds.