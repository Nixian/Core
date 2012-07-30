namespace Carbon
{
	using System;

	public struct Weight : IMeasurement<double>
	{
		public const double KilogramsInPound = 0.45359237d;
		public const double PoundsInKilogram = 2.20462262d;

		private readonly MeasurementUnit unit;
		private readonly double value;

		public Weight(double value, MeasurementUnit unit)
		{
			this.unit = unit;
			this.value = value;
		}

		public MeasurementUnit Unit
		{
			get { return unit; }
		}

		public double Value
		{
			get { return value; }
		}

		public static Weight FromKilograms(double value)
		{
			return new Weight(value, MeasurementUnit.Kilogram);
		}

		public static Weight FromPounds(double value)
		{
			return new Weight(value, MeasurementUnit.Pound);
		}

		public override string ToString()
		{
			switch(Unit)
			{
				case MeasurementUnit.Pound:		return value + " lb";
				case MeasurementUnit.Kilogram:	return value + " kg";
			}

			return base.ToString();
		}
	}

	public struct PoundsAndOunces
	{
		private readonly double totalPounds;

		public PoundsAndOunces(Weight weight)
		{
			this.totalPounds = weight.ToPounds().Value;
		}

		public int Pounds
		{
			get { return (int)System.Math.Floor(totalPounds); }
		}

		public int Ounces
		{
			get { return (int)System.Math.Floor((totalPounds - Pounds) * 16); }
		}
	}
}