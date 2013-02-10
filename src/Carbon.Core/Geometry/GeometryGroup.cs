namespace Carbon.Geometry
{
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;

	public class GeometryGroup : Collection<IGeometry>, IGeometry
	{
		public GeometryGroup() { }

		// public string Name { get; set; }

		public GeometryGroup(IEnumerable<IGeometry> items)
		{
			#region Preconditions

			if (items == null) throw new ArgumentNullException("items");

			#endregion

			foreach (var item in items)
			{
				Add(item);
			}
		}

		#region IGeographies

		public Point GetCenter()
		{
			throw new NotImplementedException();
		}

		public Rectangle GetBoundingBox()
		{
			double left = 0d, bottom = 0d, right = 0d, top = 0d;

			foreach (var item in this)
			{
				var bb = item.GetBoundingBox();

				if (bb.Left < left)		left = bb.Left;
				if (bb.Bottom < bottom) bottom = bb.Bottom;
				if (bb.Right > right)	right = bb.Right;
				if (bb.Top > top)		top = bb.Top;
			}

			return new Rectangle(left, right, bottom, top);
		}

		#endregion
	}
}
