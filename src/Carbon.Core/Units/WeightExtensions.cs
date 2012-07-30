namespace Carbon
{
	using System;

	public static class WeightExtensions
	{
		public static Weight ToPounds(this Weight weight)
		{
			switch (weight.Unit)
			{
				case MeasurementUnit.Pound: 
					return weight;

				case MeasurementUnit.Ounce: 
					return new Weight(weight.Value * 16, MeasurementUnit.Pound);

				case MeasurementUnit.Kilogram:
					return new Weight(weight.Value / Weight.KilogramsInPound, MeasurementUnit.Pound);

				default: throw new Exception("Conversion not supported");
			}
		}

		public static Weight ToKilograms(this Weight weight)
		{
			switch (weight.Unit)
			{
				case MeasurementUnit.Pound:
					return new Weight(
						value: weight.Value / Weight.PoundsInKilogram,
						unit: MeasurementUnit.Pound
					);

				case MeasurementUnit.Kilogram: 
					return weight;

				default: throw new Exception("Conversion not supported");
			}
		}

		public static PoundsAndOunces ToPoundsAndOunces(this Weight weight)
		{
			return new PoundsAndOunces(weight.ToPounds());
		}
	}
}
