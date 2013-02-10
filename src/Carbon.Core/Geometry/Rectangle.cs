namespace Carbon.Geometry
{
	public struct Rectangle
    {
		// Rethink these names
        private readonly double minX, maxX, minY, maxY;

		public Rectangle(double minX, double maxX, double minY, double maxY)
        {
            this.minX = minX;
            this.maxX = maxX;
            this.minY = minY;
            this.maxY = maxY;
        }

		public Rectangle(Point lowerLeft, Point upperRight)
		{
			minX = lowerLeft.X;
			maxX = upperRight.X;
			minY = lowerLeft.Y;
			maxY = upperRight.Y;
		}

		public double Top
		{
			get { return maxY; }
		}

		public double Bottom
		{
			get { return minY; }
		}

		public double Left
		{
			get { return minX; }
		}

		public double Right
		{
			get { return maxX; }
		}
	}
}
