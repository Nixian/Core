namespace Carbon
{
	public class UnitDetails
	{
		private readonly string text;
		private readonly UnitOfMeasurementCategory type;

		public UnitDetails(string text)
		{
			this.text = text;

			if (text.EndsWith("kg") || text.EndsWith("lb"))
			{
				type = UnitOfMeasurementCategory.Mass;
			}
		}

		public UnitOfMeasurementCategory Type
		{
			get { return type; }
		}

		public bool IsPeriod
		{
			get { return text.StartsWith("P"); }
		}

		public bool IsMass
		{
			get { return type == UnitOfMeasurementCategory.Mass; }
		}

		public bool IsDistance
		{
			get { return type == UnitOfMeasurementCategory.Distance; }
		}

		public override string ToString()
		{
			return text;
		}
	}
}
