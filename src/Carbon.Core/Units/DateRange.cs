namespace Carbon
{
	using System;
	using System.Runtime.Serialization;

	using Carbon.Helpers;

	public struct DateRange : IRange<DateTime>, IEquatable<DateRange>
	{
		private readonly DateTime start;
		private readonly DateTime end;

		public DateRange(DateTime start, DateTime end) 
		{
			#region Preconditions

			if (start > end) {
				throw new ArgumentException("The end date must be greater than the begin date");
			}

			#endregion

			this.start = start;
			this.end = end;
		}

		public DateRange(DateTime start, TimeSpan duration) {
			this.start = start;
			this.end = start + duration;
		}

		public DateTime Start {
			get { return start; }
		}

		public DateTime End {
			get { return end; }
		}

		[IgnoreDataMember]
		public TimeSpan TimeSpan {
			get { return end - start; }
		}

		public string ToIsoDateTimeDurationInterval(TimeUnit precision = TimeUnit.Second)
		{
			return start.ToIso8601(precision) + "/" + Duration.FromTimeSpan(this.TimeSpan).ToString();
		}

		#region IEquatable

		public override bool Equals(object obj)
		{
			if (obj is DateRange)
			{
				return Equals((DateRange)obj);
			}

			return false;
		}

		public bool Equals(DateRange other)
		{
			return this.Start.Equals(other.Start) && (this.End.Equals(other.End));
		}

		#endregion

		public override int GetHashCode()
		{
			return start.GetHashCode() ^ end.GetHashCode();
		}

		// 2008-01-01T5:30:00Z/PT5M

		// # Start and end, such as "2007-03-01T13:00:00Z/2008-05-11T15:30:00Z"
		// # Start and duration, such as "2007-03-01T13:00:00Z/P1Y2M10DT2H30M"
		// # Duration and end, such as "P1Y2M10DT2H30M/2008-05-11T15:30:00Z"
	}
}