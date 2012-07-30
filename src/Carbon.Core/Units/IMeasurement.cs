namespace Carbon
{
	public interface IMeasurement<T>
	{
		MeasurementUnit Unit { get; }

		T Value { get; }
	}
}