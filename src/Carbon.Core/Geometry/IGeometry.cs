namespace Carbon.Geometry
{
	public interface IGeometry
	{
		Rectangle GetBoundingBox();

		Point GetCenter();

		// TODO
		// bool Intersects(IGeography geography);
		// bool Touches(IGeography geography);
		// bool Crosses(IGeography geography);
		// bool Within(IGeography geography);
		// bool Contains(IGeography geography);
		// bool Overlaps(IGeography geography);
	}

	// Note: All geometries are current 2D
}