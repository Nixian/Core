namespace Carbon
{
	using System;

	using Carbon.Helpers;

	/// <summary>
	/// The amount of time between two specified instants, events, or states.  
	/// Can the amount of time vary (e.g. every 3rd tuesday of a month)
	/// </summary>
	public abstract class Interval
	{
		public abstract DateTime CalculateNext(DateTime current);

		public static Interval FromIsoDuration(string text)
		{
			// e.g. PT5M, P1M, P1Y, P2Y6M

			var duration = Duration.Parse(text);

			if (!duration.RequiresDelta)
			{
				return new FixedInterval(duration.ToTimeSpan());
			}
			else
			{
				if (duration.Months > 0 && duration.Years == 0)
				{
					return Monthly(duration.Months);
				}
				else if (duration.Months == 0 && duration.Years > 0)
				{
					return Yearly(duration.Years);
				}
			}

			throw new NotImplementedException();
		}

		public abstract string GetDescription();

		public abstract Duration ToDuration();

		public static FixedInterval Hourly(int number = 1)
		{
			return new FixedInterval(TimeSpan.FromHours(number));

		}
		public static FixedInterval Daily(int number = 1)
		{
			return new FixedInterval(TimeSpan.FromDays(number));
		}

		public static MonthlyInterval Monthly(int number = 1)
		{
			return new MonthlyInterval(number);
		}

		public static YearlyInterval Yearly(int number = 1) 
		{
			return new YearlyInterval(number);
		}
	}
	
	public class MonthlyInterval : Interval
	{
		private readonly int numberOfMonths;

		// TODO: Support overflow policy

		public MonthlyInterval(int numberOfMonths)
		{
			this.numberOfMonths = numberOfMonths;
		}

		public override DateTime CalculateNext(DateTime current)
		{
			return current.AddMonths(numberOfMonths);
		}

		public override Duration ToDuration()
		{
			return new Duration { Months = numberOfMonths };
		}

		public override string GetDescription()
		{
			return "{0} {1}{2}".FormatWith(numberOfMonths, "month", (numberOfMonths > 1 ? "s" : ""));
		}
	}

	public class YearlyInterval : Interval
	{
		private readonly int numberOfYears;

		public YearlyInterval(int numberOfYears)
		{
			this.numberOfYears = numberOfYears;
		}

		public override DateTime CalculateNext(DateTime current)
		{
			return current.AddYears(numberOfYears);
		}

		public override Duration ToDuration()
		{
			return new Duration { Years = numberOfYears };
		}

		public override string GetDescription()
		{
			return "{0} {1}{2}".FormatWith(numberOfYears, "year", (numberOfYears > 1 ? "s" : ""));
		}
	}

	/// <summary>
	/// A fixed period of time (e.g. 5 minutes, 30 days)
	/// </summary>
	public class FixedInterval : Interval
	{
		private readonly TimeSpan frequency;

		public FixedInterval(TimeSpan frequency) {
			this.frequency = frequency;
		}

		public TimeSpan Frequency {
			get { return frequency; } 
		}

		public override DateTime CalculateNext(DateTime current) {
			return current + frequency;
		}

		public override Duration ToDuration()
		{
			return Duration.FromTimeSpan(frequency);
		}

		public override string GetDescription()
		{
			return "{0} {1}{2}".FormatWith(frequency.TotalDays, "day", (frequency.TotalDays > 1 ? "s" : ""));
		}
	}
}