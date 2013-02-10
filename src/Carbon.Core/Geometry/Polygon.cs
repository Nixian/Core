namespace Carbon.Geometry
{
	using System;
	using System.Collections.Generic;

	// Consider renaming path

	public class Polygon : IGeometry
	{
		private readonly IList<Point> points;

		public Polygon(params Point[] points)
			: this((IList<Point>)points) { }

		public Polygon(IList<Point> points)
		{
			#region Preconditions

			if (points == null) throw new ArgumentNullException("points");

			#endregion

			this.points = points;
		}

		public IList<Point> Points
		{
			get { return points; }
		}

		#region IGeography

		public Point GetCenter()
		{
			throw new NotImplementedException();
		}

		public Rectangle GetBoundingBox()
		{
			var left = 0d;
			var bottom = 0d;
			var right = 0d;
			var top = 0d;

			foreach (Point p in this.points)
			{
				if (p.X < left)		left = p.X;
				if (p.Y < bottom) 	bottom = p.Y;
				if (p.X > right) 	right = p.X;
				if (p.Y > top) 		top = p.Y;
			}

			return new Rectangle(left, right, bottom, top);
		}

		#endregion
	}
}