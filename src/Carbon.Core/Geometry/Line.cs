namespace Carbon.Geometry
{
	public class Line : IGeometry
	{
		private readonly Point start;
		private readonly Point end;

		public Line(Point start, Point end)
		{
			this.start = start;
			this.end = end;
		}

		public Point Start
		{
			get { return start; }
		}

		public Point End
		{
			get { return end; }
		}

		#region IGeography

		public Point GetCenter()
		{
			throw new System.NotImplementedException();
		}

		public Rectangle GetBoundingBox()
		{
			throw new System.NotImplementedException();
		}

		#endregion
	}
}
