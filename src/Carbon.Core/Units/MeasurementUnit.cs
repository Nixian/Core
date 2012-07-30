namespace Carbon
{
	public enum MeasurementUnit
	{
		Unknown = 0,

		// Class 100
		// ------------ Length ------------------------------------

		Kilometer,		// 1,000 meters
		Meter,			// - Base -----
		Centimeter,		// 1/100th of a meter
		Milimeter,		// 1/1000th of a meter

		// Imperial : US/UK ---

		Mile,
		Yard,			// 3 Feet
		Foot,			// 12 Inches
		Inch,

		// Class 200
		// ------------ Mass --------------------------------------

		Kilogram,		// - Base -----					// kg
		Gram,											
		Decigram,
		Centigram,
		Milligram,

		// Imperial : US/UK ---

		Ton,			// 2,000 Pounds
		Pound,											// lb
		Ounce,

		// Class 300
		// ------------ Volume ------------------------------------

		Kilolitre,		// 1,000 litre
		Litre,			// - Base -----
		Decilitre,		// 1/10th of a litre
		Centilitre,		// 1/100th of a litre
		Millilitre,		// 1/1,000th of a litre

		// Class 400
		// ------------ Time --------------------------------------

		Century,		// 100 Years
		Decade,			// 10 Years
		Year,			// 12 Months (~365 varies)
		Month,			// 28-31 days (varies)
		Week,			// 7 Days
		Day,			// 24 Hours
		Hour,			// 60 Minutes
		Minute,			// 60 Seconds
		Second,			// Base								// s
		Milisecond,		// 1/1,000th of a second
		Nanosecond,		// 1/1,000,000th of a second

		// Class 500
		// ------------ Data (Base 2) -----------------------------

		Terabyte,		// 1 trillion (short scale) bytes
		Gigabyte,		// 1024 metabytes
		Megabyte,		// 1024 kilobytes
		Megabit,		// 1024 kilobits
		Kilobyte,		// 1024 bytes
		Kilobit,		// 1024 bits
		Byte,			// Base (8 bits)
		Bit				// 1/8th byte
	}

	public enum UnitOfMeasurementCategory
	{
		Data,
		Distance,
		Mass,
		Time,
		Current,
		Temperature,
		Volume
	}
}

/*
the meter for distance,
the kilogram for mass,
the second for time,
the ampere for electric current,
the kelvin for temperature,
the mole for amount of substance, and
the candela for intensity of light.
*/

// Previous: UnitOfMeasurement