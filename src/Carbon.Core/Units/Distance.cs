namespace Carbon
{
	using System;
	using System.Globalization;

	public struct Distance : IMeasurement<double>
	{
		public const double KilometersInMile = 1.609344000000865;
		public const double MilesInKilometer = 0.621371192237;
		public const double FeetInMile = 5280;

		public const double MetersInFoot = 0.3048;
		public const double MetersInMile = 1609.344000000865;

		private readonly double totalMeters;

		// TODO: BaseUnit

		public Distance(double meters) {
			this.totalMeters = meters;
		}

		public MeasurementUnit Unit
		{
			get { return MeasurementUnit.Meter; }
		}

		public double Value
		{
			get { return totalMeters; }
		}

		public double TotalMeters {
			get { return totalMeters; }
		}

		public double TotalKilometres {
			get { return totalMeters / 1000; }
		}

		public double TotalMiles {
			get { return totalMeters / MetersInMile; }
		}

		public static Distance FromKilometers(double kilometres)
		{
			return new Distance(kilometres * 1000);
		}

		public static Distance FromMiles(double miles)
		{
			var meters = MetersInMile * miles;

			return new Distance(meters);
		}

		#region String Overrides

		public override string ToString()
		{
			bool useMetric = RegionInfo.CurrentRegion.IsMetric;

			if (useMetric) {
				return TotalKilometres.ToString("0.0") + " km";
			}
			else {
				return TotalMiles.ToString("0.0") + " mi";
			}
		}

		#endregion
	}
}