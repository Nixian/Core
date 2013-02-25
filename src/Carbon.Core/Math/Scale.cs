namespace Carbon
{
	// A mathmatical relationship between input and output
	// ƒ(x) -> y
 
	public abstract class Scale
	{
		public static LinearScale Linear(Range<double> domain, Range<double> range)
		{
			return new LinearScale(domain, range);
		}
	}

	public class LinearScale : Scale
	{
		private readonly Range<double> domain;
		private readonly Range<double> range;

		private readonly double domainSpan;
		private readonly double rangeSpan;

		/// <param name="domain">The input range</param>
		/// <param name="range">The output range</param>
		public LinearScale(Range<double> domain, Range<double> range)
		{
			this.domain = domain;
			this.range = range;

			// The 'widths' of each range
			this.domainSpan = domain.GetSpan();
			this.rangeSpan = range.GetSpan();
		}

		public double Map(double input)
		{
			// Input as a percentage of the span
			var scaledInput = (input - domain.Start) / domainSpan;

			// Map that percentage to the range span
			return range.Start + (scaledInput * rangeSpan);
		}
	}

	public static class RangeExtensions
	{
		public static double GetSpan(this Range<double> range)
		{
			return range.End - range.Start;
		}
	}
}
