namespace Carbon.Geometry
{
	using System;

	public struct Point : IPoint, IGeometry
	{
		public readonly static Point Zero = new Point(0, 0);

		private readonly double x;
		private readonly double y;

		public Point(double x, double y) 
		{
			this.x = x;
			this.y = y;
		}

		// Latitude
		public double X
		{
			get { return x; }
		}

		// Longitude
		public double Y
		{
			get { return y; }
		}

		#region IGeography

		public Point GetCenter()
		{
			return this;
		}

		public Rectangle GetBoundingBox()
		{
			return new Rectangle(X, X, Y, Y);
		}

		#endregion

		#region Equality

		public override int GetHashCode()
		{
			return x.GetHashCode() + y.GetHashCode();
		}

		public override bool Equals(object obj)
		{
			var point = (Point)obj;

			return (point.X == this.x) && (point.Y == this.y);
		}

		#endregion

		#region Operators

		public static Point operator +(Point p1, Point p2)
		{
			return new Point(p1.X + p2.X, p1.Y + p2.Y);
		}

		public static Point operator -(Point p1, Point p2)
		{
			return new Point(p1.X - p2.X, p1.Y - p2.Y);
		}

		public static double operator *(Point p1, Point p2)
		{
			return p1.X * p2.X + p1.Y * p2.Y;
		}

		public static Point operator *(Point value, double scale)
		{
			return new Point(
				x: value.X * scale,
				y: value.Y * scale
			);
		}

		public static Point operator *(double scale, Point value)
		{
			return value * scale;
		}

		public static bool operator ==(Point a, Point b)
		{
			return (a.X == b.X) && (a.Y == b.Y);
		}

		public static bool operator !=(Point a, Point b)
		{
			return !(a == b);
		}

		#endregion

		public override string ToString()
		{
			return String.Join(",", x, y);
		}

		public static Point Parse(string text)
		{
			#region Preconditions

			if (text == null) throw new ArgumentNullException("text");

			#endregion

			var split = text.Split(',');

			return new Point(
				x: Double.Parse(split[0]),
				y: Double.Parse(split[1])
			);

		}
	}
}